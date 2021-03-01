using Business.Abstract;
using Core.Business;
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
using Core.Aspects.Autofac.Validation;
using Business.ValidationRules.FluentValidation;

namespace Business.Concrete
{
    public class RentalManager : BusinessManagerBase<Rental>, IRentalService
    {
        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal):base(rentalDal)
        {
            _rentalDal = (IRentalDal)base._entityDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public override IResult Add(Rental entity)
        {
            return base.Add(entity);
        }

        [ValidationAspect(typeof(RentalValidator))]
        public override IResult Update(Rental entity)
        {
            return base.Update(entity);
        }

        [ValidationAspect(typeof(RentalValidator))]
        public override IResult Delete(Rental entity)
        {
            return base.Delete(entity);
        }

        public IDataResult<List<RentalDetailDto>> GetAllRentalsDetails()
        {
            try
            {
                return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetDetails());
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<RentalDetailDto>>(e.Message);
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
                return new ErrorDataResult<List<RentalDetailDto>>(e.Message);
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
