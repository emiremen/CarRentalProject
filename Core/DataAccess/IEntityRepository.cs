﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    public interface IEntityRepository<Tip> where Tip : class, IEntity, new()
    {
        Tip GetById(Expression<Func<Tip,bool>> filter);
        List<Tip> GetAll(Expression<Func<Tip, bool>> filter = null);
        void Add(Tip entity);
        void Update(Tip entity);
        void Delete(Tip entity);
    }
}
