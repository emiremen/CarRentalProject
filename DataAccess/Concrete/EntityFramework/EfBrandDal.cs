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
    public class EfBrandDal : IBrandDal
    {
        public void Add(Brand entity)
        {
            using (MyDBContext dBContext = new MyDBContext())
            {
                if (entity.CarBrand.Length > 2)
                {
                    var addedBrand = dBContext.Entry(entity);
                    addedBrand.State = EntityState.Added;
                    dBContext.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Lütfen 2 karakterden uzun bir isim giriniz.");
                }

            }
        }

        public void Delete(Brand entity)
        {
            using (MyDBContext dBContext = new MyDBContext())
            {
                var deletedBrand = dBContext.Entry(entity);
                deletedBrand.State = EntityState.Deleted;
                dBContext.SaveChanges();
            }
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using (MyDBContext dBContext = new MyDBContext())
            {
                return filter == null ? dBContext.Set<Brand>().ToList() : dBContext.Set<Brand>().Where(filter).ToList();
            }
        }

        public Brand GetById(Expression<Func<Brand, bool>> filter)
        {
            using (MyDBContext dBContext = new MyDBContext())
            {
                return dBContext.Set<Brand>().SingleOrDefault(filter);
            }
        }

        public void Update(Brand entity)
        {
            using (MyDBContext dBContext = new MyDBContext())
            {
                if (entity.CarBrand.Length > 2)
                {
                    var updatedBrand = dBContext.Entry(entity);
                    updatedBrand.State = EntityState.Modified;
                    dBContext.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Lütfen 2 karakterden uzun bir isim giriniz.");
                }
            }
        }

    }
}
