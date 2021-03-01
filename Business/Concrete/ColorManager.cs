using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Business;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
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

        [ValidationAspect(typeof(ColorValidator))]
        public override IResult Add(Color entity)
        {
            return base.Add(entity);
        }
    }
}
