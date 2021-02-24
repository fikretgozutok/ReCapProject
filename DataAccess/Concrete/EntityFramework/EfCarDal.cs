using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentSystemContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(int? id = null)
        {
            using (CarRentSystemContext context = new CarRentSystemContext())
            {
                if (id == null)
                {
                    var result = from c in context.Cars
                                 join b in context.Brands
                                 on c.BrandId equals b.Id
                                 join clr in context.Colors
                                 on c.ColorId equals clr.Id
                                 join m in context.Models
                                 on c.ModelId equals m.Id
                                 select new CarDetailDto
                                 {
                                     Id = c.Id,
                                     Brand = b.Name,
                                     Model = m.Name,
                                     Color = clr.Name,
                                     DailyPrice = c.DailyPrice,
                                     Description = c.Description,
                                     ModelYear = c.ModelYear
                                 };
                    
                    return result.ToList();
                }
                else
                {
                    var result = from c in context.Cars
                                 where c.Id == id
                                 join b in context.Brands
                                 on c.BrandId equals b.Id
                                 join clr in context.Colors
                                 on c.ColorId equals clr.Id
                                 join m in context.Models
                                 on c.ModelId equals m.Id
                                 select new CarDetailDto
                                 {
                                     Id = c.Id,
                                     Brand = b.Name,
                                     Model = m.Name,
                                     Color = clr.Name,
                                     DailyPrice = c.DailyPrice,
                                     Description = c.Description,
                                     ModelYear = c.ModelYear
                                 };
                    
                    return result.ToList();
                }
            }
        }
    }
}
