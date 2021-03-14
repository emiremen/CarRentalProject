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
        public IResult Add(CarImage carImage,IFormFile file)
        {
            IResult result = BusinessRules.Run(CheckImageLimit(carImage.CarId));
            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
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

        public IResult Update(int id, IFormFile file)
        {
            var carImage = _carImageDal.GetById(c => c.Id == id);
            carImage.ImagePath = FileHelper.Update(file, carImage.ImagePath);
            carImage.Date = DateTime.Now;
            carImage.CarId = carImage.CarId;
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        //################################# Rules
        private IResult CheckImageLimit(int carId)
        {
            var result = _carImageDal.GetAll(p=>p.CarId == carId);
            if (result.Count > 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceded);
            }
            return new SuccessResult();
        }
    }
}
