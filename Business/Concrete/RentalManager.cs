﻿using Business.Abstract;
using Core.Business;
using Core.DataAccess;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.Utilities.Results.Concrete;
using Business.Constants;
using Entities.DTOs;

namespace Business.Concrete
{
    public class RentalManager<Dal> : BusinessManagerBase<Rental, Dal>, IRentalService
        where Dal : class, IEntityRepository<Rental>, new()
    {
        private IRentalDal _rentalDal;

        public RentalManager()
        {
            _rentalDal = (IRentalDal)_entityDal;
        }

        public IDataResult<List<RentalDetailDto>> GetAllRentalsDetails()
        {
            try
            {
                return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetDetails());
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<RentalDetailDto>>();
            }
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails(int id)
        {
            try
            {
                return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetDetails(id));
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<RentalDetailDto>>();
            }
        }

        public IResult RentCar(Rental entity)
        {
            var result = _rentalDal.GetAll().FindAll(r => r.ReturnDate == null);

            if (result.Count >= 0 && result.SingleOrDefault(r=>r.CarId == entity.CarId) == default(Rental))
            {
                return base.Add(entity);               
            }

            return new ErrorResult(Messages.notReturnedYet);
        }

        public IResult ReturnedCar(Rental entity)
        {
            var result = _rentalDal.GetAll().FindAll(r => r.ReturnDate == null);

            if (result.Count > 0 && result.SingleOrDefault(r => r.CarId == entity.CarId) != default(Rental))
            {
                return base.Update(entity);
            }

            return new ErrorResult(Messages.notRented);
        }
    }
}
