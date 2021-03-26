using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarProductDal : EfEntityRepositoryBase<Car, MyDBContext>, ICarProductDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (MyDBContext dBContext = new MyDBContext())
            {
                var result = from car in dBContext.Cars
                             join b in dBContext.Brands on car.BrandId equals b.Id
                             join c in dBContext.Colors on car.ColorId equals c.Id
                             select new CarDetailDto
                             {
                                 CarId = car.Id,
                                 BrandName = b.CarBrand,
                                 ColorName = c.CarColor,
                                 ModelYear = car.ModelYear,
                                 //CarImage = dBContext.CarImages.Where(c => c.CarId == car.Id).Select(i => i.ImagePath).ToArray(),
                                 CarImage =  (from carImage in dBContext.CarImages where carImage.CarId == car.Id select carImage.ImagePath).ToList(),
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description
                             };

                if (filter == null)
                {
                    return result.ToList();
                }
                return result.Where(filter).ToList();
            }
        }
    }
}
