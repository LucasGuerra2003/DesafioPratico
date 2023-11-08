using System;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Linq;
using System.IO;

namespace DesafioPrático1
{
    static class Criptografia
    {
        public static byte[] CapturaChave(string chavecapturada)
        {
           SHA256 sha256 = SHA256.Create();
            return sha256.ComputeHash(Encoding.UTF8.GetBytes(chavecapturada));
        }

        public static string criptografiaAES(string senha, byte[] chavecriptografia)
        {
            Aes aesAlg = Aes.Create();

            aesAlg.Key = chavecriptografia;
            aesAlg.IV = new byte[16];

            ICryptoTransform Criptografia = aesAlg.CreateEncryptor();

            byte[] Criptografado;

            MemoryStream MemoriaStream = new MemoryStream();
            CryptoStream CriptografiaStream = new CryptoStream(MemoriaStream, Criptografia, CryptoStreamMode.Write);
            StreamWriter SWCriptografar = new StreamWriter(CriptografiaStream);
            
            try
            {
 
            }
            finally
            {
                if (SWCriptografar != null)
                    SWCriptografar.Close();
            }

            Criptografado = MemoriaStream.ToArray();


            return Convert.ToBase64String(Criptografado);
        }

        public static string criptografiaRSA(string senha, RSAParameters ParametrosRSA)
        {
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            RSA.ImportParameters(ParametrosRSA);
            byte[] data = Encoding.UTF8.GetBytes(senha);
            byte[] encryptedData = RSA.Encrypt(data, true);
            return Convert.ToBase64String(encryptedData);
        }

        public static string CriptografiaSHA256(string senha, string chave)
        {
            string chavesenha = senha + chave;
            var sha256Hash = SHA256.Create();
            var bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(chavesenha));
            var build = new StringBuilder();

            foreach (var bts in bytes)
            {
                build.Append(bts.ToString("x2"));
            }

            return build.ToString();


        }
    }
}
