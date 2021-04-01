using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results.Concrete;
using Core.Business;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;

namespace Business.Concrete
{
    public class CarManager : BusinessManagerBase<Car>, ICarService
    {
        private ICarDal _carDal;
        public CarManager(ICarDal carDal):base(carDal)
        {
            _carDal = (ICarDal)_entityDal;
        }


        [ValidationAspect(typeof(CarValidator))]
        [TransactionScopeAspect]
        [CacheRemoveAspect("ICarService.Get")]
        public override IResult Add(Car entity)
        {
            return base.Add(entity);
        }

        [CacheRemoveAspect("ICarService.Get")]
        [TransactionScopeAspect]
        public override IResult Update(Car entity)
        {
            return base.Update(entity);
        }

        [CacheRemoveAspect("ICarService.Get")]
        [TransactionScopeAspect]
        public override IResult Delete(Car entity)
        {
            return base.Delete(entity);
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetails(int carId)
        {
            try
            {
                return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(carId));
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<CarDetailDto>>(e.Message);
            }
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            try
            {
                _carDal.GetAll(c=>c.BrandId == brandId);
                return new SuccessDataResult<List<Car>>();
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<Car>>(e.Message);
            }
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            try
            {
                _carDal.GetAll(c => c.ColorId == colorId);
                return new SuccessDataResult<List<Car>>();
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<Car>>(e.Message);
            }
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetAllCarsDetails()
        {
            try
            {
                return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<CarDetailDto>>(e.Message);
            }
        }

    }
}
