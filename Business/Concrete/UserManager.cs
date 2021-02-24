using Business.Abstract;
using Core.Business;
using Core.DataAccess;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager<Dal> : BusinessManagerBase<User, Dal>, IUserService
        where Dal : class, IEntityRepository<User>, new()
    {
    }
}
