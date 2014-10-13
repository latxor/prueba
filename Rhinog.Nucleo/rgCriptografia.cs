using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Rhinog
{
    /// <summary>    
    /// <Autor>FREDDY GAVIRIA OLIVERA</Autor> 
    /// <Fecha>19/03/2013</Fecha> 
    /// <Descripción>Contiene los metodos para encriptacion y desencriptacion de cadenas, utilizando
    /// el algoritmo DES</Descripción>  
    /// <Versión> 1 </Versión>
    /// <Revisiones> Ninguna </Revisiones>
    /// <Modificaciones>  
    /// <item1></item1>
    /// </Modificaciones> 
    /// </summary> 
    /// <url>http://www.dijksterhuis.org/encrypting-decrypting-string/</url>
    public static class rgCriptografia
    {
        /// <summary>
        /// Realiza la encriptacion de una cadena de caracteres tomando de base una llave de encriptacion
        /// </summary>
        /// <param name="mensaje_">Mensaje a encriptar</param>
        /// <param name="llave_">Llave de encriptacion</param>
        /// <returns>Informacion encriptada</returns>
        public static string EncriptarCadena(string mensaje_, string llave_)
        {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

            // Step 1. We hash the passphrase using MD5
            // We use the MD5 hash generator as the result is a 128 bit byte array
            // which is a valid length for the TripleDES encoder we use below

            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(llave_));

            // Step 2. Create a new TripleDESCryptoServiceProvider object
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

            // Step 3. Setup the encoder
            TDESAlgorithm.Key       = TDESKey;
            TDESAlgorithm.Mode      = CipherMode.ECB;
            TDESAlgorithm.Padding   = PaddingMode.PKCS7;

            // Step 4. Convert the input string to a byte[]
            byte[] DataToEncrypt = UTF8.GetBytes(mensaje_);

            // Step 5. Attempt to encrypt the string
            try
            {
                ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
            }
            finally
            {
                // Clear the TripleDes and Hashprovider services of any sensitive information
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            // Step 6. Return the encrypted string as a base64 encoded string
            return Convert.ToBase64String(Results);
        }

        /// <summary>
        /// Realiaza el proceso de desencriptar un mensaje por medio de una llave
        /// </summary>
        /// <param name="mensaje_">Mensaje encriptado</param>
        /// <param name="llave_">Llave</param>
        /// <returns>Informacion desencriptada</returns>
        public static string DesencriptarCadena(string mensaje_, string llave_)
        {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

            // Step 1. We hash the passphrase using MD5
            // We use the MD5 hash generator as the result is a 128 bit byte array
            // which is a valid length for the TripleDES encoder we use below

            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(llave_));

            // Step 2. Create a new TripleDESCryptoServiceProvider object
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

            // Step 3. Setup the decoder
            TDESAlgorithm.Key       = TDESKey;
            TDESAlgorithm.Mode      = CipherMode.ECB;
            TDESAlgorithm.Padding   = PaddingMode.PKCS7;

            // Step 4. Convert the input string to a byte[]
            byte[] DataToDecrypt = Convert.FromBase64String(mensaje_);

            // Step 5. Attempt to decrypt the string
            try
            {
                ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
            }
            finally
            {
                // Clear the TripleDes and Hashprovider services of any sensitive information
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            // Step 6. Return the decrypted string in UTF8 format
            return UTF8.GetString(Results);
        }

    }
}
