using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarProductDal _carProduct;
        public CarManager(ICarProductDal carProduct)
        {
            _carProduct = carProduct;
        }
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 21)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceError);
            }
            return new SuccessDataResult<List<Car>>(_carProduct.GetAll(),Messages.Listed);
        }

        public IDataResult<Car> GetCarById(int carId)
        {
            return new SuccessDataResult<Car>(_carProduct.GetById(p => p.Id == carId),Messages.Listed);
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            _carProduct.Add(car);
            return new SuccessResult("Eklendi");
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            _carProduct.Update(car);
            return new SuccessResult("Güncellendi");
        }
        public IResult Delete(Car car)
        {
            _carProduct.Add(car);
            return new SuccessResult("Silindi");
        }

        public IDataResult<List<Car>> GetCarsByBrand(int Id)
        {
            return new SuccessDataResult<List<Car>>(_carProduct.GetAll(p => p.BrandId == Id), Messages.Listed);
        }

        public IDataResult<List<Car>> GetCarsByColor(int Id)
        {
            return new SuccessDataResult<List<Car>>(_carProduct.GetAll(p => p.ColorId == Id), Messages.Listed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            if (DateTime.Now.Hour == 21)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceError);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carProduct.GetCarDetails(),Messages.Listed);
        }
    }
}
