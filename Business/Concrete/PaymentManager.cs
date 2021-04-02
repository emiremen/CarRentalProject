using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        private IPaymentDal _paymentDal;

        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }

        [TransactionScopeAspect]
        public IResult Add(Payment payment)
        {
            _paymentDal.Add(payment);
            return new SuccessResult(Messages.Added);
        }

        [TransactionScopeAspect]
        public IResult Delete(Payment payment)
        {
            _paymentDal.Delete(payment);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Payment>> GetAllPayments()
        {
            return new SuccessDataResult<List<Payment>>(_paymentDal.GetAll(),Messages.Listed);
        }

        public IDataResult<Payment> GetPaymentByCustomerId(int customerId)
        {
            return new SuccessDataResult<Payment>(_paymentDal.GetById(p => p.CustomerId == customerId));
        }

        [TransactionScopeAspect]
        public IResult Update(Payment payment)
        {
            _paymentDal.Update(payment);
            return new SuccessResult(Messages.Updated);
        }
    }
}
