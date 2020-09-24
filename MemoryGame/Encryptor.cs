using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Security
{
    class Encryptor
    {
        // Set the password
        static readonly string Password = "RandomgEneraTeDsTriNg";

        // Set the IV (initialization vector) value
        static readonly string IV = "@5B2C6G2s5H2F1p0";

        public string Encrypt(string rawInput)
        {
            // Will contain the encrypted value later
            byte[] encrypted;

            // Gets the input string and converts it to a byte array
            byte[] inputBytes = Encoding.UTF8.GetBytes(rawInput);

            using (RijndaelManaged rijAlg = new RijndaelManaged())
            {
                // Create an encryptor to perform the stream transform
                ICryptoTransform encryptor = rijAlg.CreateEncryptor(Password, IV);

                // Create the streams used for encryption
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream
                            swEncrypt.Write(inputBytes);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            return encrypted;
        }

        public string Decrypt(string encryptedInput)
        {
            // Will contain the decrypted value later
            string decrypted = null;

            // Gets the input string and converts it to a byte array
            byte[] inputBytes = Encoding.UTF8.GetBytes(encryptedInput);

            using (RijndaelManaged rijAlg = new RijndaelManaged())
            {
                // Create a decryptor to perform the stream transform
                ICryptoTransform decryptor = rijAlg.CreateDecryptor(Password, IV);

                // Create the streams used for decryption
                using (MemoryStream msDecrypt = new MemoryStream(inputBytes))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            // Read the decrypted bytes from the decrypting stream and place them in a string
                            decrypted = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return decrypted;
        }
    }
}
