using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey security)
        {
            //Kullanıcı adı ve şifre bir credential dır.
            return new SigningCredentials(security, SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
