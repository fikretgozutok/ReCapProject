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


namespace Business.Concrete
{
    public class CarManager : BusinessManagerBase<Car>, ICarService
    {
        private ICarDal _carDal;
        public CarManager(ICarDal carDal):base(carDal)
        {
            _carDal = (ICarDal)_entityDal;
        }

        public override IResult Add(Car entity)
        {
            if (entity.DailyPrice > 0)
            {
                return base.Add(entity);
            }

            return new ErrorDataResult<Car>(Messages.priceError);
            
        }

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
