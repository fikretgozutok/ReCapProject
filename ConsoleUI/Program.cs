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
            //AddNewUser();
            //AddNewCustomer();
            RentSystem();
            Console.ReadLine();
        }

        static void AddNewUser()
        {
            UserManager<EfUserDal> userManager = new UserManager<EfUserDal>();
            userManager.Add(new User 
            {
                FirstName = "Fikret",
                LastName = "Gözütok",
                Email = "fikret@mail.com",
                Password = "123"
            });
            userManager.Add(new User
            {
                FirstName = "İsmail",
                LastName = "Demir",
                Email = "ism@mail.com",
                Password = "abc"
            });
            userManager.Add(new User
            {
                FirstName = "Hakan",
                LastName = "Özcan",
                Email = "sinyor@mail.com",
                Password = "nevarb3"
            });
        }
        static void AddNewCustomer()
        {
            CustomerManager<EfCustomerDal> customerManager = new CustomerManager<EfCustomerDal>();
            customerManager.Add(new Customer 
            {
                UserId = 2,
                CompanyName = "Demir Tekstil"
            });
        }
        static void RentSystem()
        {
            RentalManager<EfRentalDal> rentalManager = new RentalManager<EfRentalDal>();
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
                Console.WriteLine("Id = {0}",item.Id);
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
