﻿using Business.Abstract;
using Business.Constants;
using Core.Business;
using Core.DataAccess;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ModelManager<Dal> : BusinessManagerBase<Model, Dal>, IModelService
        where Dal : class, IEntityRepository<Model>, new()
    {
        public override IResult Add(Model entity)
        {
            if (entity.Name.Length >=2)
            {
                return base.Add(entity);
            }

            return new ErrorResult(Messages.nameError);
        }
    }
}
