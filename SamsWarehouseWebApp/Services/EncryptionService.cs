using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Security.Cryptography;

namespace UploadEncryption.Services
{
    public class EncryptionService
    {
        private readonly string _secretKey;

        public EncryptionService(IConfiguration config)
        {
            _secretKey = config["SecretKey"];
        }

        public byte[] EncryptByteArray(byte[] fileData) 
        {
            //return byte[5]
            using (AesManaged aesAlg = new AesManaged())
            {
                // Convert the key to a byte[]
                aesAlg.Key = System.Text.Encoding.UTF8.GetBytes(_secretKey);

                // Create a Transform
                ICryptoTransform encryptor= aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt= new MemoryStream())
                {
                    msEncrypt.Write(aesAlg.IV, 0, 16);

                    // Encrypts the image with cryptostream
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        csEncrypt.Write(fileData,0, fileData.Length);   
                        csEncrypt.FlushFinalBlock();
                        return msEncrypt.ToArray();
                    }
                }
            }
        }

        public byte[] DecryptByteArray(byte[] encryptedFileData)
        {
            using (AesManaged aesAlg = new AesManaged())
            {
                aesAlg.Key = System.Text.Encoding.UTF8.GetBytes(_secretKey);
                byte[] IV = new byte[16];
                Array.Copy(encryptedFileData, 0, IV, 0, 16);

                ICryptoTransform decryptor= aesAlg.CreateDecryptor(aesAlg.Key, IV);

                using (MemoryStream msDecrypt= new MemoryStream(encryptedFileData))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Write))
                    {
                        csDecrypt.Write(encryptedFileData, 16, encryptedFileData.Length - 16);
                        csDecrypt.FlushFinalBlock();
                        return msDecrypt.ToArray();
                    }
                }
            }
        }
    }
}
