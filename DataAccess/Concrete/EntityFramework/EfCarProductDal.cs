using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarProductDal : EfEntityRepositoryBase<Car, MyDBContext>, ICarProductDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (MyDBContext dBContext = new MyDBContext())
            {
                var result = from car in dBContext.Cars
                             join b in dBContext.Brands on car.BrandId equals b.Id
                             join c in dBContext.Colors on car.ColorId equals c.Id
                             select new CarDetailDto
                             {
                                 BrandName = b.CarBrand,
                                 ColorName = c.CarColor,
                                 ModelYear = car.ModelYear,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description
                             };

                return result.ToList();
            }
        }
    }
}
