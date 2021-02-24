using Core.DataAccess.EntityFramework;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentSystemContext>, IRentalDal
    {
        public List<RentalDetailDto> GetDetails(int? id = null)
        {
            using (CarRentSystemContext context = new CarRentSystemContext())
            {
                if (id == null)
                {
                    var result = from r in context.Rentals
                                 join c in context.Cars
                                 on r.CarId equals c.Id
                                 join b in context.Brands
                                 on c.BrandId equals b.Id
                                 join clr in context.Colors
                                 on c.ColorId equals clr.Id
                                 join m in context.Models
                                 on c.ModelId equals m.Id
                                 join cstmr in context.Customers
                                 on r.CustomerId equals cstmr.Id
                                 join u in context.Users
                                 on cstmr.UserId equals u.Id
                                 select new RentalDetailDto
                                 {
                                     Id = r.Id,
                                     CarBrand = b.Name,
                                     CarId = c.Id,
                                     CarModel = m.Name,
                                     CustomerCompany = cstmr.CompanyName,
                                     CustomerMail = u.Email,
                                     CustomerName = u.FirstName,
                                     CustomerSurname = u.LastName,
                                     DailyRentPrice = c.DailyPrice,
                                     RentDate = r.RentDate,
                                     ReturnDate = r.ReturnDate
                                 };

                    return result.ToList();
                }
                else
                {
                    var result = from r in context.Rentals
                                 where r.Id == id
                                 join c in context.Cars
                                 on r.CarId equals c.Id
                                 join b in context.Brands
                                 on c.BrandId equals b.Id
                                 join clr in context.Colors
                                 on c.ColorId equals clr.Id
                                 join m in context.Models
                                 on c.ModelId equals m.Id
                                 join cstmr in context.Customers
                                 on r.CustomerId equals cstmr.Id
                                 join u in context.Users
                                 on cstmr.UserId equals u.Id
                                 select new RentalDetailDto
                                 {
                                     Id = r.Id,
                                     CarBrand = b.Name,
                                     CarId = c.Id,
                                     CarModel = m.Name,
                                     CustomerCompany = cstmr.CompanyName,
                                     CustomerMail = u.Email,
                                     CustomerName = u.FirstName,
                                     CustomerSurname = u.LastName,
                                     DailyRentPrice = c.DailyPrice,
                                     RentDate = r.RentDate,
                                     ReturnDate = r.ReturnDate
                                 };

                    return result.ToList();
                }
            }
            
            
        }
    }
}
