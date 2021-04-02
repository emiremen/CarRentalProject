using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, MyDBContext>, IRentalDal
    {
        public Rental GetRentalByCarIdWithGreatestReturnDay(Expression<Func<Rental, bool>> filter)
        {
            using (MyDBContext dBContext = new MyDBContext())
            {
                return dBContext.Set<Rental>().Where(filter).OrderByDescending(filter).FirstOrDefault();
            }
        }
    

        public List<RentedCarDetailDto> GetRentedCarDetails()
        {
            using (MyDBContext dBContext = new MyDBContext())
            {
                var result = from car in dBContext.Cars
                             join r in dBContext.Rentals on car.Id equals r.CarId
                             join cust in dBContext.Customers on r.CustomerId equals cust.Id
                             join u in dBContext.Users on cust.UserId equals u.Id
                             join b in dBContext.Brands on car.BrandId equals b.Id
                             join c in dBContext.Colors on car.ColorId equals c.Id
                             select new RentedCarDetailDto
                             {
                                 Customer = u.FirstName + " " + u.LastName,
                                 CompanyName = cust.CompanyName,
                                 CarBrand = b.CarBrand,
                                 CarColor = c.CarColor,
                                 CarModelYear = car.ModelYear,
                                 RentedDate = r.RentedDate,
                                 ReturnDate = r.ReturnDate
                             };

                             return result.ToList();
            }
        }
    }
}
