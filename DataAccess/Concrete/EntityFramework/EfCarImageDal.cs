using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarImageDal : EfEntityRepositoryBase<CarImage, MyDBContext>, ICarImageDal
    {
        public List<CarImage> GetCarImagesByCarId(Expression<Func<CarImage, bool>> filter)
        {
            using (MyDBContext dBContext = new MyDBContext())
            {
                return dBContext.CarImages.Where(filter).ToList();
            }

        }
    }
}
