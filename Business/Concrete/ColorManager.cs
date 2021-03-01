using Business.Abstract;
using Business.ValidationRules.FluentValidation;
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

        public override IResult Add(Color entity)
        {
            var context = new ValidationContext<Color>(entity);
            ColorValidator colorValidator = new ColorValidator();
            var result = colorValidator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
            return base.Add(entity);
        }
    }
}
