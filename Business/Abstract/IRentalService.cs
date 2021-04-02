using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<Rental> Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
        IDataResult<List<Rental>> GetAllRentals();
        IDataResult<Rental> GetRentalById(int rentalId);
        IDataResult<Rental> GetRentalByCarId(int carId);
        IDataResult<List<RentedCarDetailDto>> GetRentedCarDetail();
    }
}
