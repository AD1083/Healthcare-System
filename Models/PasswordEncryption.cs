using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Healthcare_System.Models
{
    class PasswordEncryption
    {
        //property to allow login service to access the encrypted password
        public string EncryptedPassword { get; }

        /// <summary>
        /// constructor for password encryption
        /// takes the unecrypted string as a parameter and sets the encrypted value to the property
        /// </summary>
        /// <param name="passwordToEncrypt"></param>
        public PasswordEncryption(string passwordToEncrypt)
        {
            EncryptedPassword = Encrypt(passwordToEncrypt);
        }

        /// <summary>
        /// Method to encrypt a plain text password using the SHA256 alogrithm
        /// </summary>
        /// <param name="password">The plain-text password to encrypt</param>
        /// <returns>String containing chars which have been produced by hashing the password</returns>
        private string Encrypt(string password)
        {
            //using sha256 algorithm to encrypt the password string into a hash; source:
            //https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.sha256?view=netframework-4.8

            //create new default SHA256 instance
            SHA256 shaHash = SHA256.Create();
            //create a byte array of each byte in the password string, as the algorithm uses the byte value to hash
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            //now use the algorithm to create a byte array of hashed bytes, using the bytes of the string password
            byte[] passwordHash = shaHash.ComputeHash(passwordBytes);

            //to convert to string the StringBuilder class is used 
            //this converts each byte in the hashed array to a string before concatenating them all together
            StringBuilder stringBuilder = new StringBuilder();
            foreach (byte hashedByte in passwordHash)
            {
                stringBuilder.Append(hashedByte.ToString("x2")); //converting each byte and adding to the string
            }

            //returns the built hashed password string
            return stringBuilder.ToString();
        }
    }
}
