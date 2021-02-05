using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetById(int BrandId);
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
    }
}
