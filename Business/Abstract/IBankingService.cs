using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBankingService
    {
        IResult Add(Banking banking);
        IResult Update(Banking banking);
        IResult Delete(Banking banking);
        IDataResult<Banking> GetBankingByUserId(int userId);
        IDataResult<List<Banking>> GetAllBankings();
        IDataResult<Banking> GetByFilter(Banking banking);
    }
}
