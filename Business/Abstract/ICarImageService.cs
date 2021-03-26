using Core.Business;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService : IBusinessService<CarImage>
    {
        IResult Add(CarImage entity, IFormFile file);
        IResult Update(CarImage entity, IFormFile file);
        IDataResult<List<CarImage>> GetByCarId(int carId);
    }
}
