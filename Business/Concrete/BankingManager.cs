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
    public class BankingManager : IBankingService
    {
        private IBankingDal _bankingDal;

        public BankingManager(IBankingDal bankingDal)
        {
            _bankingDal = bankingDal;
        }

        public IResult Add(Banking banking)
        {
            _bankingDal.Add(banking);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Banking banking)
        {
            _bankingDal.Delete(banking);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Banking>> GetAllBankings()
        {
            return new SuccessDataResult<List<Banking>>(_bankingDal.GetAll(), Messages.Listed);
        }

        public IDataResult<Banking> GetBankingByUserId(int userId)
        {
            return new SuccessDataResult<Banking>(_bankingDal.GetById(b => b.UserId == userId), Messages.Listed);
        }

        public IResult Update(Banking banking)
        {
            throw new NotImplementedException();
        }
    }
}
