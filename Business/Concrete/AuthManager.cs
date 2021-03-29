using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private ITokenHelper _tokenHelper;
        private IUserService _userService;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            try
            {
                List<OperationClaim> operationClaims = _userService.GetClaims(user).Data;
                var token = _tokenHelper.CreateToken(user, operationClaims);

                return new SuccessDataResult<AccessToken>(Messages.AccessTokenCreated, token);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<AccessToken>(e.InnerException.ToString());
            }
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            try
            {
                var user = _userService.GetUserByMail(userForLoginDto.Email).Data;
                if (user == null)
                {
                    return new ErrorDataResult<User>(Messages.UserNotFound);
                }
                var verifyHashResult = HashingHelper.VerifyPasswordHash(userForLoginDto.Password, user.PasswordHash, user.PasswordSalt);
                if (!verifyHashResult)
                {
                    return new ErrorDataResult<User>(Messages.PasswordError);
                }

                return new SuccessDataResult<User>(user);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<User>(e.InnerException.ToString());
            }
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            try
            {
                byte[] passwordHash, passwordSalt;

                HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);

                User user = new User
                {
                    Email = userForRegisterDto.Email,
                    FirstName = userForRegisterDto.FirstName,
                    LastName = userForRegisterDto.LastName,
                    Status = true,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                };

                var res = _userService.Add(user);
                if (res.Success)
                {
                    return new SuccessDataResult<User>(user);
                }

                return new ErrorDataResult<User>(res.Message);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<User>(e.InnerException.ToString());
            }
        }

        public IResult UserExists(string mail)
        {
            //Kullanıcı varsa successde true yoksa false döner.
            var userToCheck = _userService.GetUserByMail(mail);
            if (!userToCheck.Success)
            {
                return new ErrorResult(Messages.UserNotFound);
            }
            return new SuccessResult(Messages.UserAlreadyExists);
        }
    }
}
