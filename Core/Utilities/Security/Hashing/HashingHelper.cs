using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        //Hashleme aracı

        public static void CreatePasswordHash
            (string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            //Bu metod kendisine verilen şifre üzerinde salt işlemini gerçekleştirerek hash oluşturacak
            //Parametre olarak istenen out dışarı verilecek

            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key; //Anlık oluşturulan keydir. Her kullanıcı için farklıdır.
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            //Parametre olarak verilen passwordü aynı salt ile hashleseydin aynı hash değerini mi elde ederdin
            using (var hmac = new HMACSHA512(passwordSalt)) //Kullanılacak salt parametre olarak verilir..
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }
    }
}
