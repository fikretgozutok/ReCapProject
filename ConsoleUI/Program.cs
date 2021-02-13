using System;
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System.Collections.Generic;
using Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.DTOs;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            ModelNameManager modelNameManager = new ModelNameManager(new EfModelNameDal());

            //AddColors(colorManager);
            //AddBrands(brandManager);
            //AddModelNames(modelNameManager);
            //AddCars(carManager);


            /*Car test

            carManager.Add(new Car { BrandId = 1, ColorId = 1, DailyPrice = 1, Description = "dfja", ModelNameId = 1, ModelYear = 3});
            carManager.Update(new Car { Id = 12, BrandId = 1, ColorId = 1, DailyPrice = 1, Description = "jklşjklşjjşkljşlkjlkşj", ModelNameId = 1, ModelYear = 3 });
            carManager.Delete(new Car { Id = 12});
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.Description);
            }
            foreach (var item in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine(item.Description);
            }
            foreach (var item in carManager.GetCarsByColorId(1))
            {
                Console.WriteLine(item.Description);
            }
            Console.WriteLine(carManager.GetById(1).Description);*/

            List<CarDetailDto> list = carManager.GetCarDetais().Data;
            //Console.WriteLine(list.Count);
            foreach (var item in list)
            {
                Console.WriteLine("********************\n" +
                    "Araç :\n" +
                    "Marka Model : {0}\n" +
                    "Renk : {1}\n" +
                    "Kiralama Ücreti : {2} TL\n" +
                    "Açıklama : {3}\n" +
                    "********************\n",
                    item.BrandName + " " + item.ModelName,
                    item.ColorName,
                    item.DailyPrice,
                    item.Description);
            }




            Console.ReadLine();
        }

        static void AddColors(ColorManager manager)
        {
            List<Color> list = new List<Color>
            {
                new Color{Name = "Beyaz"},
                new Color{Name = "Siyah"},
                new Color{Name = "Gri"},
                new Color{Name = "Lacivert"},
                new Color{Name = "Kırmızı"},
                new Color{Name = "Sarı"},
            };

            foreach (var item in list)
            {
                manager.Add(item);
            }
        }
        static void AddBrands(BrandManager manager)
        {
            List<Brand> list = new List<Brand>
            {
                new Brand{Name = "Ford"},
                new Brand{Name = "Chevrolet"},
                new Brand{Name = "Volkswagen"},
                new Brand{Name = "BMW"},
                new Brand{Name = "Audi"},

            };

            foreach (var item in list)
            {
                manager.Add(item);
            }
        }
        static void AddModelNames(ModelNameManager manager)
        {
            List<ModelName> list = new List<ModelName>
            {
                new ModelName{BrandId = 1, Name = "Mustang Mach 1"},
                new ModelName{BrandId = 1, Name = "Fiesta"},
                new ModelName{BrandId = 1, Name = "GT"},
                new ModelName{BrandId = 1, Name = "Mondeo Sedan"},

                new ModelName{BrandId = 2, Name = "Camaro"},
                new ModelName{BrandId = 2, Name = "Corvette"},

                new ModelName{BrandId = 3, Name = "CC"},
                new ModelName{BrandId = 3, Name = "Passat"},
                new ModelName{BrandId = 3, Name = "Golf"},
                new ModelName{BrandId = 3, Name = "Tiguan"},

                new ModelName{BrandId = 4, Name = "M8 Gran Coupe"},

                new ModelName{BrandId = 5, Name = "A1 Sportback"},
                new ModelName{BrandId = 5, Name = "Q4"},


            };

            foreach (var item in list)
            {
                manager.Add(item);
            }
        }

        static void AddCars(CarManager manager)
        {
            List<Car> list = new List<Car>
            {
                new Car{BrandId = 1, ColorId = 1, ModelNameId = 1, DailyPrice = 5000, ModelYear = 1969, Description = "Efsane Ford Mustang 1969"},
                new Car{BrandId = 2, ColorId = 4, ModelNameId = 5, DailyPrice = 3000, ModelYear = 2015, Description = "Camaro otomatik"},
                new Car{BrandId = 4, ColorId = 5, ModelNameId = 11, DailyPrice = 2800, ModelYear = 2018, Description = "bmw m8"},
                new Car{BrandId = 1, ColorId = 2, ModelNameId = 3, DailyPrice = 3300, ModelYear = 2010, Description = "ford gt otomatik"},
                new Car{BrandId = 5, ColorId = 1, ModelNameId = 12, DailyPrice = 1600, ModelYear = 2016, Description = "a1 otomatik"},
                new Car{BrandId = 3, ColorId = 4, ModelNameId = 10, DailyPrice = 1000, ModelYear = 2016, Description = "tiguan manuel"},
                new Car{BrandId = 4, ColorId = 5, ModelNameId = 11, DailyPrice = 2800, ModelYear = 2014, Description = "bmw m8"},
                new Car{BrandId = 3, ColorId = 6, ModelNameId = 8, DailyPrice = 700, ModelYear = 2015, Description = "passat manuel"},
                new Car{BrandId = 5, ColorId = 6, ModelNameId = 13, DailyPrice = 1200, ModelYear = 2013, Description = "audi q4 manuel"},
                new Car{BrandId = 1, ColorId = 2, ModelNameId = 2, DailyPrice = 150, ModelYear = 1994, Description = "fiesta manuel"},
                new Car{BrandId = 5, ColorId = 3, ModelNameId = 13, DailyPrice = 1300, ModelYear = 2015, Description = "audi q4"},


            };
            
            
            foreach (var item in list)
            {
                manager.Add(item);
            }
        }

        
    }
}
