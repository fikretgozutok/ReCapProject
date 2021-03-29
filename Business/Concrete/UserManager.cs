using Business.Abstract;
using Core.Business;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results.Concrete;
using Business.Constants;

namespace Business.Concrete
{
    public class UserManager : BusinessManagerBase<User>, IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal) : base(userDal) { _userDal = userDal; }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            try
            {
                var claims = _userDal.GetClaims(user);
                return new SuccessDataResult<List<OperationClaim>>(claims);
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<OperationClaim>>(Messages.fetchError);
            }
        }

        public IDataResult<User> GetUserByMail(string mail)
        {
            var user = _userDal.Get(u => u.Email == mail);
            if (user == null)
            {
                return new ErrorDataResult<User>();
            }
            return new SuccessDataResult<User>(user);
        }
    }
}
