using Business.Abstract;
using Core.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : BusinessManagerBase<Color>, IColorService
    {
        private IColorDal _colorDal;
        public ColorManager(IColorDal colorDal):base(colorDal)
        {
            _colorDal = colorDal;
        }
    }
}
