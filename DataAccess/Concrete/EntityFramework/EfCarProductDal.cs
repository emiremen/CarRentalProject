using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarProductDal : ICarProductDal
    {
        public void Add(Car entity)
        {
            using (MyDBContext dBContext = new MyDBContext())
            {
                if (entity.DailyPrice > 0)
                {
                    var addedEntity = dBContext.Entry(entity);
                    addedEntity.State = EntityState.Added;
                    dBContext.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Lütfen sıfırdan yüksek bir fiyat giriniz.");
                }
            }
        }

        public void Delete(Car entity)
        {
            using (MyDBContext dBContext = new MyDBContext())
            {
                var deletedEntity = dBContext.Entry(dBContext);
                deletedEntity.State = EntityState.Deleted;
                dBContext.SaveChanges();
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (MyDBContext dBContext = new MyDBContext())
            {
                return filter == null ? dBContext.Set<Car>().ToList() : dBContext.Set<Car>().Where(filter).ToList();
            }
        }

        public Car GetById(Expression<Func<Car, bool>> filter)
        {
            using (MyDBContext dBContext = new MyDBContext())
            {
                return dBContext.Set<Car>().SingleOrDefault(filter);
            }
        }

        public void Update(Car entity)
        {
            using (MyDBContext dBContext = new MyDBContext())
            {
                if (entity.DailyPrice > 0)
                {
                    var updatedContext = dBContext.Entry(dBContext);
                    updatedContext.State = EntityState.Modified;
                    dBContext.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Lütfen sıfırdan büyük bir fiyat belirleyiniz.");
                }
            }
        }
    }
}
