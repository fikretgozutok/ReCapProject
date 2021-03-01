using Business.Abstract;
using Core.Business;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : BusinessManagerBase<User>, IUserService
    {
        private IUserDal _userDal;
        public UserManager(IUserDal userDal):base(userDal)
        {
            _userDal = userDal;
        }
    }
}
