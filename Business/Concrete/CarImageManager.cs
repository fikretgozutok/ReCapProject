using Business.Abstract;
using Business.Constants;
using Core.Business;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : BusinessManagerBase<CarImage>, ICarImageService
    {
        public CarImageManager(ICarImageDal imageDal) : base(imageDal) { }

        public IResult Add(CarImage entity, IFormFile file)
        {
            var res = BusinessRules.Run
                (IsImageLimitExceeded(entity.CarId),
                IsAddDefault(entity.CarId));

            try
            {
                if (res == null)
                {

                    var path = FileHelper.Add(file);
                    entity.ImagePath = path;
                    entity.Date = DateTime.Now;
                    _entityDal.Add(entity);
                    return new SuccessResult(Messages.addedEntityMessage);
                }

                return res;

            }
            catch (Exception e)
            {
                return new ErrorResult(e.InnerException.ToString());
            }
        }

        public override IResult Delete(CarImage entity)
        {
            var res = BusinessRules.Run(IsDeleteDefault(entity));
            try
            {
                if (res == null)
                {
                    var item = _entityDal.Get(c => c.Id == entity.Id);
                    FileHelper.Delete(item.ImagePath);
                    _entityDal.Delete(item);
                    return new SuccessResult(Messages.deletedEntityMessage);
                }

                return res;

            }
            catch (Exception e)
            {
                return new ErrorResult(e.InnerException.ToString());
            }
        }

        public IResult Update(CarImage entity, IFormFile file)
        {
            try
            {
                var item = _entityDal.Get(c => c.Id == entity.Id);
                FileHelper.Delete(item.ImagePath);
                var newPath = FileHelper.Add(file);
                entity.ImagePath = newPath;
                entity.CarId = item.CarId;
                entity.Date = item.Date;
                _entityDal.Update(entity);
                return new SuccessResult(Messages.updatedEntityMessage);
            }
            catch (Exception e)
            {
                return new ErrorResult(e.InnerException.ToString());
            }
        }



        //BusinessRules
        public IResult IsImageLimitExceeded(int carId)
        {
            var res = _entityDal.GetAll(c => c.CarId == carId);
            if (res.Count >= 5)
            {
                return new ErrorResult(Messages.imageLimitExceeded);
            }
            return new SuccessResult();
        }

        public IResult IsAddDefault(int carId)
        {
            var carImages = _entityDal.GetAll(c => c.CarId == carId);
            if (carImages.Count == 1)
            {
                foreach (var image in carImages)
                {
                    if (image.ImagePath == FileHelper.DefaultPath())
                    {
                        _entityDal.Delete(image);
                    }
                }
            }

            return new SuccessResult();
        }
        public IResult IsDeleteDefault(CarImage carImage)
        {
            var carId = _entityDal.Get(x => x.Id == carImage.Id).CarId;
            var carImages = _entityDal.GetAll(c => c.CarId == carId);
            if (carImages.Count == 1)
            {
                _entityDal.Add(new CarImage
                {
                    CarId = carId,
                    Date = DateTime.Now,
                    ImagePath = FileHelper.DefaultPath()
                });;
            }

            return new SuccessResult();
        }
    }
}
