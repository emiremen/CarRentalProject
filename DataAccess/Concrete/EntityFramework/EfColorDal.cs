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
    public class EfColorDal : IColorDal
    {
        public void Add(Color entity)
        {
            using (MyDBContext dBContext = new MyDBContext())
            {
                var addedColor = dBContext.Entry(entity);
                addedColor.State = EntityState.Added;
                dBContext.SaveChanges();
            }
        }

        public void Delete(Color entity)
        {
            using (MyDBContext dBContext = new MyDBContext())
            {
                var deletedColor = dBContext.Entry(entity);
                deletedColor.State = EntityState.Deleted;
                dBContext.SaveChanges();
            }
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (MyDBContext dBContext = new MyDBContext())
            {
                return filter == null ? dBContext.Set<Color>().ToList() : dBContext.Set<Color>().Where(filter).ToList();
            }
        }

        public Color GetById(Expression<Func<Color, bool>> filter)
        {
            using (MyDBContext dBContext = new MyDBContext())
            {
                return dBContext.Set<Color>().SingleOrDefault(filter);
            }
        }

        public void Update(Color entity)
        {
            using (MyDBContext dBContext = new MyDBContext())
            {
                var updatedColor = dBContext.Entry(entity);
                updatedColor.State = EntityState.Modified;
                dBContext.SaveChanges();
            }
        }
    }
}
