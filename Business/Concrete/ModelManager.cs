using Business.Abstract;
using Business.Constants;
using Core.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class ModelManager : BusinessManagerBase<Model>, IModelService
    {
        private IModelDal _modelDal;

        public ModelManager(IModelDal modelDal):base(modelDal)
        {
            _modelDal = modelDal;
        }
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
