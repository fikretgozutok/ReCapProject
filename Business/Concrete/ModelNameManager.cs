using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;

namespace Business.Concrete
{
    public class ModelNameManager : IModelNameService
    {
        private IModelNameDal _modelNameDal;
        public ModelNameManager(IModelNameDal modelNameDal)
        {
            _modelNameDal = modelNameDal;
        }

        public IResult Add(ModelName modelName)
        {
            _modelNameDal.Add(modelName);
            return new SuccessResult();
        }

        public IResult Delete(ModelName modelName)
        {
            _modelNameDal.Delete(modelName);
            return new SuccessResult();
        }

        public IDataResult<ModelName> Get(int modelNameId)
        {
            return new SuccessDataResult<ModelName>(_modelNameDal.Get(mn=>mn.Id == modelNameId));
        }

        public IDataResult<List<ModelName>> GetAll()
        {
            return new SuccessDataResult<List<ModelName>>(_modelNameDal.GetAll());
        }

        public IDataResult<List<ModelName>> GetByBrandId(int brandId)
        {
            return new SuccessDataResult<List<ModelName>>(_modelNameDal.GetAll(mn=>mn.BrandId == brandId));
        }

        public IResult Update(ModelName modelName)
        {
            _modelNameDal.Update(modelName);
            return new SuccessResult();
        }
    }
}
