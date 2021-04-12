using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    class UserBankCardManager : IUserBankCardService
    {
        private IUserBankCardDal _userBankCardDal;

        public UserBankCardManager(IUserBankCardDal userBankCardDal)
        {
            _userBankCardDal = userBankCardDal;
        }

        public IResult Add(UserBankCard userBankCard)
        {
            _userBankCardDal.Add(userBankCard);
            return new SuccessDataResult<Rental>(Messages.Added);
        }

        public IResult Delete(UserBankCard userBankCard)
        {
            _userBankCardDal.Delete(userBankCard);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<UserBankCard>> GetUserBankCardsByUserId(int userId)
        {
            var result = _userBankCardDal.GetAll(b => b.UserId == userId);
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<UserBankCard>>(result, Messages.Listed);
            }
            return new ErrorDataResult<List<UserBankCard>>(result, Messages.Listed);
        }

        public IResult Update(UserBankCard userBankCard)
        {
            _userBankCardDal.Delete(userBankCard);
            return new SuccessResult(Messages.Deleted);
        }
    }
}
