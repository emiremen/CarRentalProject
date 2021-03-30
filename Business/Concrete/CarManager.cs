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
using Business.BusinessAspects.Autofac;

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
            return new SuccessDataResult<List<Car>>(_carProduct.GetAll(),Messages.Listed);
        }

        public IDataResult<Car> GetCarById(int carId)
        {
            return new SuccessDataResult<Car>(_carProduct.GetById(p => p.Id == carId),Messages.Listed);
        }

        //Claim 
        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IDataResult<Car> Add(Car car)
        {
            _carProduct.Add(car);
            return new SuccessDataResult<Car>(car, "Eklendi");
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
            return new SuccessDataResult<List<CarDetailDto>>(_carProduct.GetCarDetails(),Messages.Listed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandName(string brandName)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carProduct.GetCarDetails(p=>p.BrandName == brandName), Messages.Listed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByColorName(string colorName)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carProduct.GetCarDetails(p=>p.ColorName == colorName), Messages.Listed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByFiltered(string brandName, string colorName)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carProduct.GetCarDetails(p=>p.ColorName == colorName && p.BrandName == brandName), Messages.Listed);
        }

        public IDataResult<CarDetailDto> GetCarDetailsById(int carId)
        {
             return new SuccessDataResult<CarDetailDto>(_carProduct.GetCarDetails(p => p.CarId == carId)[0], Messages.Listed);
        }
    }
}
