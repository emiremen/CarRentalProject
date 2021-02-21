using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
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
            return _carProduct.GetById(carId);
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
    }
}
