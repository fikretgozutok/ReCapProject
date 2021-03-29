using System;
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System.Collections.Generic;
using Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.DTOs;
using System.IO;
using Core.Entities.Concrete;
using Business.Abstract;
using Core.Utilities.Security.Hashing;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //AddNewUser();
            //AddNewCustomer();
            //RentSystem();
            //Test();

            byte[] passwordHash, passwordSalt;
            string password = "fikret123";
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var result = HashingHelper.VerifyPasswordHash("fikret123", passwordHash, passwordSalt);
            Console.WriteLine(result);
            Console.ReadLine();
        }

        private static void Test()
        {
            ICarService carService = new CarManager(new EfCarDal());
            var res = carService.Add(new Car
            {
                BrandId = 1,
                ColorId = 1,
                DailyPrice = 300,
                Description = "temiz otomatik vites",
                ModelId = 1,
                ModelYear = 2014
            });
            Console.WriteLine(res.Success);
        }

        static void AddNewUser()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(new User
            {
                FirstName = "Fikret",
                LastName = "Gözütok",
                Email = "fikret@mail.com",
            });
            userManager.Add(new User
            {
                FirstName = "İsmail",
                LastName = "Demir",
                Email = "ism@mail.com",
            });
            userManager.Add(new User
            {
                FirstName = "Hakan",
                LastName = "Özcan",
                Email = "sinyor@mail.com",
            });
        }
        static void AddNewCustomer()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Customer
            {
                UserId = 2,
                CompanyName = "Demir Tekstil"
            });
        }
        static void RentSystem()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            /*var res = rentalManager.RentCar(new Rental
            {
                CarId = 8,
                CustomerId = 1,
                RentDate = new DateTime(2021,02,24),
                ReturnDate = null
            });*/

            /*var res = rentalManager.ReturnedCar(new Rental
            {
                Id = 1,
                CarId = 8,
                CustomerId = 1,
                RentDate = new DateTime(2021, 02, 24),
                ReturnDate = new DateTime(2021, 02, 27)
            });*/

            var res = rentalManager.GetAllRentalsDetails();

            //Console.WriteLine(res.Success);
            //Console.WriteLine(res.Data.Count);

            foreach (var item in res.Data)
            {
                Console.WriteLine("Id = {0}", item.Id);
                Console.WriteLine("Araç Id = {0}", item.CarId);
                Console.WriteLine("Müşteri İsmi = {0}", item.CustomerName);
                Console.WriteLine("Müşteri Soyismi = {0}", item.CustomerSurname);
                Console.WriteLine("Müşteri Mail = {0}", item.CustomerMail);
                Console.WriteLine("Müşteri Şirket = {0}", item.CustomerCompany);
                Console.WriteLine("Araç Marka = {0}", item.CarBrand);
                Console.WriteLine("Araç Model = {0}", item.CarModel);
                Console.WriteLine("Günlük kira fiyatı = {0}TL", item.DailyRentPrice);
                Console.WriteLine("Kiralama Tarihi = {0}", item.RentDate.ToString());
                Console.WriteLine("Geri Dönüş Tarihi = {0}", item.ReturnDate.ToString());
                Console.WriteLine("*******************************************************");
            }
        }
    }
}
