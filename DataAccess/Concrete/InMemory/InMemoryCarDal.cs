using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> cars;

        public InMemoryCarDal()
        {
            cars = new List<Car>
            {
                new Car{Id = 1, BrandId = 1, ColorId = 3, DailyPrice = 60000, Description = "Ford Mustang 1969 Mach 1", ModelYear = 1969},
                new Car{Id = 2, BrandId = 2, ColorId = 2, DailyPrice = 14400, Description = "Toyota Supra 3.0 Turbo", ModelYear = 1991},
                new Car{Id = 3, BrandId = 3, ColorId = 1, DailyPrice = 46800, Description = "Chevrolet Camaro 2.0 Turbo", ModelYear = 2016},
                new Car{Id = 4, BrandId = 1, ColorId = 3, DailyPrice = 58000, Description = "Ford Thunderbird", ModelYear = 1964},
                new Car{Id = 5, BrandId = 3, ColorId = 1, DailyPrice = 42300, Description = "Chevrolet Impala", ModelYear = 1979},
            };
        }
        public void Add(Car car)
        {
            cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = cars.SingleOrDefault(c=>c.Id == car.Id);
            cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return cars;
        }

        public List<Car> GetById(int Id)
        {
            return cars.Where(c=>c.Id == Id).ToList();
        }

        public void Update(Car car)
        {
            Car tempCar = cars.SingleOrDefault(c=>c.Id == car.Id);
            tempCar.BrandId = car.BrandId;
            tempCar.ColorId = car.ColorId;
            tempCar.DailyPrice = car.DailyPrice;
            tempCar.Description = car.Description;
            tempCar.ModelYear = car.ModelYear;
        }
    }
}
