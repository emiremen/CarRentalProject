using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBankingDal : EfEntityRepositoryBase<Banking, MyDBContext>, IBankingDal
    {
        public Banking GetByFilter(Expression<Func<Banking, bool>> filter)
        {
                using (MyDBContext dBContext = new MyDBContext())
                {
                    return dBContext.Set<Banking>().SingleOrDefault(filter);
                }
        }
    }
}
