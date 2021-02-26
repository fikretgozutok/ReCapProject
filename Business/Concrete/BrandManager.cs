using Business.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Business;
using Entities.Concrete;
using Core.DataAccess;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class BrandManager : BusinessManagerBase<Brand>, IBrandService
    {
        private IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal):base(brandDal)
        {
            _brandDal = brandDal;
        }
    }
}
