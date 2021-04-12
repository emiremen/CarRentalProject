using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserBankCardService
    {
        IResult Add(UserBankCard userBankCard);
        IResult Update(UserBankCard userBankCard);
        IResult Delete(UserBankCard userBankCard);
        IDataResult<List<UserBankCard>> GetUserBankCardsByUserId(int userId);
    }
}
