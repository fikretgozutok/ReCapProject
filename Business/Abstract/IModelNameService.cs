using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Core.Utilities.Results.Abstract;

namespace Business
{
    public interface IModelNameService
    {
        IResult Add(ModelName modelName);
        IResult Update(ModelName modelName);
        IResult Delete(ModelName modelName);
        IDataResult<List<ModelName>> GetAll();
        IDataResult<ModelName> Get(int modelNameId);
        IDataResult<List<ModelName>> GetByBrandId(int brandId);
    }
}
