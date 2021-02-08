using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ModelNameManager : IModelNameService
    {
        private IModelNameDal _modelNameDal;
        public ModelNameManager(IModelNameDal modelNameDal)
        {
            _modelNameDal = modelNameDal;
        }

        public void Add(ModelName modelName)
        {
            _modelNameDal.Add(modelName);
        }

        public void Delete(ModelName modelName)
        {
            _modelNameDal.Delete(modelName);
        }

        public ModelName Get(int modelNameId)
        {
            return _modelNameDal.Get(mn=>mn.Id == modelNameId);
        }

        public List<ModelName> GetAll()
        {
            return _modelNameDal.GetAll();
        }

        public List<ModelName> GetByBrandId(int brandId)
        {
            return _modelNameDal.GetAll(mn=>mn.BrandId == brandId);
        }

        public void Update(ModelName modelName)
        {
            _modelNameDal.Update(modelName);
        }
    }
}
