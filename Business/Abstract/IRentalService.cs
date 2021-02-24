using Core.Business;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService : IBusinessService<Rental>
    {
        IResult RentCar(Rental entity);
        IResult ReturnedCar(Rental entity);
        IDataResult<List<RentalDetailDto>> GetAllRentalsDetails();
        IDataResult<List<RentalDetailDto>> GetRentalDetails(int id);


    }
}
