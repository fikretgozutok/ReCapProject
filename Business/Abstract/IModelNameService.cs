using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business
{
    public interface IModelNameService
    {
        void Add(ModelName modelName);
        void Update(ModelName modelName);
        void Delete(ModelName modelName);
        List<ModelName> GetAll();
        ModelName Get(int modelNameId);
        List<ModelName> GetByBrandId(int brandId);
    }
}
