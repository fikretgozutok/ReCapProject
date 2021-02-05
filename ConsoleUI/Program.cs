using System;
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System.Collections.Generic;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            LoopManager(carManager.GetAll());

            Console.WriteLine("-------------------------------------------------------------------");

            LoopManager(carManager.GetById(3));

            Console.WriteLine("-------------------------------------------------------------------");

            carManager.Add(new Entities.Concrete.Car { 
            Id = 6, BrandId = 1, ColorId = 3, DailyPrice = 30220, ModelYear = 2020, Description = "Ford F-150XL"
            });

            LoopManager(carManager.GetAll());

            Console.WriteLine("-------------------------------------------------------------------");
            
            carManager.Delete(new Car { Id = 3});

            LoopManager(carManager.GetAll());

            Console.WriteLine("-------------------------------------------------------------------");

            carManager.Update(new Car { Id = 6, BrandId = 1, ColorId = 4, DailyPrice = 39500, ModelYear = 2021, Description = "New Ford F-150XL 2021"});

            LoopManager(carManager.GetAll());

            Console.Read();
        }

        static void ShowData(int Id, int BrandId, int ColorId, int ModelYear, decimal DailyPrice, string Description)
        {
            Console.WriteLine("\n******************" +
                    "\nId = {0}" +
                    "\nBrandId = {1}" +
                    "\nColorId = {2}" +
                    "\nModelYear = {3}" +
                    "\nDailyPrice = {4} USD" +
                    "\nDescription = {5}" +
                    "\n******************",
                    Id,BrandId, ColorId, ModelYear, DailyPrice, Description);
        }

        static void LoopManager(List<Car> list)
        {
            foreach (Car car in list)
            {
                ShowData(car.Id, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description);
            }
        }
    }
}
