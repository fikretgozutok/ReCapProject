using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentSystemContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarRentSystemContext context = new CarRentSystemContext())
            {
                var result = from c in context.Cars
                             join clr in context.Colors
                             on c.ColorId equals clr.Id
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join mn in context.ModelNames
                             on c.ModelNameId equals mn.Id
                             select new CarDetailDto
                             {
                                 ModelName = mn.Name,
                                 BrandName = b.Name,
                                 ColorName = clr.Name,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description
                             };
                return result.ToList();
            }
        }
    }
}
