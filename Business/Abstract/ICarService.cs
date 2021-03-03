using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
        List<Car> GetAll();
        Car GetCarById(int carId);
        List<Car> GetCarsByBrand(int Id);
        List<Car> GetCarsByColor(int Id);
        List<CarDetailDto> GetCarDetails();
    }
}
