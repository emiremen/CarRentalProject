using Core.Utilities;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<Car> Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetCarById(int carId);
        IDataResult<List<Car>> GetCarsByBrand(int Id);
        IDataResult<List<Car>> GetCarsByColor(int Id);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<CarDetailDto> GetCarDetailsById(int carId);
        IDataResult<List<CarDetailDto>> GetCarDetailsByBrandName(string brandName);
        IDataResult<List<CarDetailDto>> GetCarDetailsByColorName(string colorName);
        IDataResult<List<CarDetailDto>> GetCarDetailsByFiltered(string brandName, string colorName);
        IResult AddTransactionTest(Car car);
    }
}
