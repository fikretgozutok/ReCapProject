using Business.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Business;
using Entities.Concrete;
using Core.DataAccess;

namespace Business.Concrete
{
    public class BrandManager<Dal> : BusinessManagerBase<Brand, Dal>, IBrandService
        where Dal: class, IEntityRepository<Brand>, new()
    {
    }
}
