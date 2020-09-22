using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Meemoree.scope
{
    class Encryptor
    {
        static readonly string Password = "ImagineUsingAnActualPasswordOMEGALUL";
        static readonly string Salt     = "PrettySalty";
        static readonly string VI       = "@5B2C6G2s5H2F1p0";
        public string Encrypt(string input)
        {
            byte[] encryptedText;

            //Gets the byte array values if the input text
            byte[] inputBytes           = Encoding.UTF8.GetBytes(input);
            //Intitializes a new Rfc2898DeriveBytes class with a password and the salt. It generates the key we'll be using.
            byte[] Key                  = new Rfc2898DeriveBytes(Password, Encoding.ASCII.GetBytes(Salt)).GetBytes(256 / 8);
            //Creates the key well be using for the actual encryptor. Which it'll use to encrypt and decrypt data
            var encryptorkey            = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
            //Sets the actual encryptor with the key and VI
            var encryptor               = encryptorkey.CreateEncryptor(Key, Encoding.ASCII.GetBytes(VI));
            
            //Opens a new memoryStream
            using (var memStream        = new MemoryStream())
            {
                //Uses the memoryStream and the encryptor to create a CryptoStream
                using (var cryptoStream = new CryptoStream(memStream, encryptor, CryptoStreamMode.Write))
                {
                    //Writes the inputtext in bytes to the stream at 0 position
                    cryptoStream.Write(inputBytes, 0, inputBytes.Length);
                    //Flushes the changes
                    cryptoStream.FlushFinalBlock();
                    //changes the stream data type to a byte array
                    encryptedText = memStream.ToArray();
                    //we close both streams
                    cryptoStream.Close();
                }
                memStream.Close();
            }
            // and return the encrypted string
            return Convert.ToBase64String(encryptedText);
        }

        public string Decrypt(string cipherString)
        {
            //We convert the cipher to a byte array
            byte[] cipherBytes      = Convert.FromBase64String(cipherString);
            //We set the return as a byte array with the length of the cipher bytes
            byte[] returnBytes      = new byte[cipherBytes.Length];
            //We generate the same keybytes so we can decrypt the data since we have the same iv salt and pass
            byte[] KeyBytes         = new Rfc2898DeriveBytes(Password, Encoding.ASCII.GetBytes(Salt)).GetBytes(256 / 8);
            var RijndaelManaged     = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };
            //We use the same generation parameters to generate the same encryptor (decryptor)
            var decryptor           = RijndaelManaged.CreateDecryptor(KeyBytes, Encoding.ASCII.GetBytes(VI));
            //We set a new memorystream with the cipher in it
            var memoryStream        = new MemoryStream(cipherBytes);
            //We set a new cryptoStream with the memoreyStream and decryptor in it (the actual decoding also happends here)
            var cryptoStream        = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            //We set the character count of the decrypted string
            int decryptedByteCount  = cryptoStream.Read(returnBytes, 0, returnBytes.Length);
            //We close both streams
            memoryStream.Close();
            cryptoStream.Close();
            //And return the decoded data as a string (we remove the end byte "\0")
            return Encoding.UTF8.GetString(returnBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
        }
    }
}
