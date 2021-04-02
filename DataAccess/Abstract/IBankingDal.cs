using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IBankingDal : IEntityRepository<Banking>
    {
        Banking GetByFilter(Expression<Func<Banking, bool>> filter);
    }
}
