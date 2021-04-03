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
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarProductDal _carProduct;
        public CarManager(ICarProductDal carProduct)
        {
            _carProduct = carProduct;
        }

        [PerformanceAspect(5)] //Metodun Çalışması 5 saniyeyi geçerse uyar
        [CacheAspect] //key, value
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carProduct.GetAll(),Messages.Listed);
        }

        [CacheAspect]
        public IDataResult<Car> GetCarById(int carId)
        {
            return new SuccessDataResult<Car>(_carProduct.GetById(p => p.Id == carId),Messages.Listed);
        }

        //Claim 
        [TransactionScopeAspect]
        //[SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IDataResult<Car> Add(Car car)
        {
            _carProduct.Add(car);
            return new SuccessDataResult<Car>(car, "Eklendi");
        }

        [CacheRemoveAspect("IProductService.Get")]
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

        public IResult AddTransactionTest(Car car)
        {
            Add(car);

            if (car.DailyPrice < 10)
            {
                throw new Exception("Hata");
            }

            Add(car);
            return null;
        }
    }
}
