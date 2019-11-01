using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Encryption
{
    class Program
    {
        static void Main()
        {
            for (int i = 0; i < 6; i++)
            {
                Console.Write("\nEnter Password: ");
                string password = Console.ReadLine().ToString();
                Console.WriteLine($"\nYour password: {password}");
                string encryptedPassword = Encrypt(password);
                Console.WriteLine($"\nYour password encrypted: {encryptedPassword}");
            }

            Console.ReadKey();
        }

        private static string Encrypt(string password)
        {
            //using sha256 algorithm
            //https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.sha256?view=netframework-4.8
            SHA256 shaHash = SHA256.Create();
            byte[] hash = shaHash.ComputeHash(Encoding.UTF8.GetBytes(password));

            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                stringBuilder.Append(hash[i].ToString("x2"));
            }

            return stringBuilder.ToString();
        }
    }
}
// do some exmaplw code for timer triggering each module to read and chek