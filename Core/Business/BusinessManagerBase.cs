using Core.Entities;
using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess;
using Core.Utilities.Results.Concrete;
using System.Linq.Expressions;

namespace Core.Business
{
    public class BusinessManagerBase<Tentity> : IBusinessService<Tentity>
        where Tentity : class, IEntity, new()
    {
        protected IEntityRepository<Tentity> _entityDal;

        
        public BusinessManagerBase(IEntityRepository<Tentity> entityDal)
        {
            _entityDal = entityDal;
        }

        public virtual IResult Add(Tentity entity)
        {
            try
            {
                _entityDal.Add(entity);
                return new SuccessResult("Veri kaydı başarılı");
            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);
            }
        }

        public virtual IResult Delete(Tentity entity)
        {
            try
            {
                _entityDal.Delete(entity);
                return new SuccessResult("Veri kaydı başarılı");
            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);
            }
        }

        public virtual IDataResult<Tentity> GetById(int id)
        {
            try
            {
                var entity = _entityDal.Get(e=>e.Id == id);
                return new SuccessDataResult<Tentity>(entity);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<Tentity>(e.Message);
            }
        }

        public virtual IDataResult<List<Tentity>> GetAll()
        {
            try
            {
                var entity = _entityDal.GetAll();
                return new SuccessDataResult<List<Tentity>>(entity);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<Tentity>>(e.Message);
            }
        }

        public virtual IResult Update(Tentity entity)
        {
            try
            {
                _entityDal.Update(entity);
                return new SuccessResult("Veri güncellemesi başarılı");
            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);
            }
        }
    }
}
