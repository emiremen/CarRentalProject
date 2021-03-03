using Business.Abstract;
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
        public List<Car> GetAll()
        {
            return _carProduct.GetAll();
        }

        public Car GetCarById(int carId)
        {
            return _carProduct.GetById(p=>p.Id == carId);
        }

        public void Add(Car car)
        {
            _carProduct.Add(car);
        }

        public void Update(Car car)
        {
            _carProduct.Update(car);
        }
        public void Delete(Car car)
        {
            _carProduct.Delete(car);
        }

        public List<Car> GetCarsByBrand(int Id)
        {
            return _carProduct.GetAll(p=>p.BrandId == Id);
        }

        public List<Car> GetCarsByColor(int Id)
        {
            return _carProduct.GetAll(p => p.ColorId == Id);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carProduct.GetCarDetails();
        }
    }
}
