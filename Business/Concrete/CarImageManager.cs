using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        public IResult Add(int toSavedCarId, IFormFile[] file)
        {
            IResult result = BusinessRules.Run(CheckImageLimit(toSavedCarId));
            if (result != null)
            {
                return result;
            }

            var files = FileHelper.Add(file);
            foreach (var item in files)
            {
                CarImage carImage = new CarImage();
                carImage.CarId = toSavedCarId;
                carImage.ImagePath = item;
                carImage.Date = DateTime.Now;
                _carImageDal.Add(carImage);
            }

            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            FileHelper.Delete(carImage.ImagePath);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAllImages()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetImagesById(int carId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.GetById(p => p.Id == carId));
        }

        public IResult Update(int toUpdateCarId, IFormFile[] file)
        {
            CarImage[] carImage = _carImageDal.GetCarImagesByCarId(c => c.Id == toUpdateCarId).ToArray();

            var files = FileHelper.Update(file, carImage.Select(p => p.ImagePath).ToArray());
            int sayac = 0;
            foreach (var item in files)
            {
                carImage[sayac].ImagePath = item;
                carImage[sayac].CarId = toUpdateCarId;
                carImage[sayac].ImagePath = item;
                carImage[sayac].Date = DateTime.Now;
                _carImageDal.Update(carImage[sayac]);
                sayac++;
            }
            return new SuccessResult();
        }

        //################################# Rules
        private IResult CheckImageLimit(int carId)
        {
            var result = _carImageDal.GetAll(p => p.CarId == carId);
            if (result.Count > 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceded);
            }
            return new SuccessResult();
        }
    }
}
