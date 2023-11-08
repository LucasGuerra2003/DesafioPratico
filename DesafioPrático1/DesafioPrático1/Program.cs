using System;
using System.Security.Cryptography;
using System.Text;

namespace DesafioPrático1
{
    class Program
    {
        static void Main(string[] args)
        {
            string chaveSecreta = "#modalGR#GPTW#top#maiorEmpresaTecnologia#baixadaSantista";
            byte[] bytesChaves = Criptografia.CapturaChave(chaveSecreta);

            int i = 1;
            string senha = "admin";
            Console.WriteLine("Chave Secreta para Criptografia: " + chaveSecreta);

            Console.WriteLine("Senha para Criptografia: " + senha + "\n");


            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            RSAParameters parametrosRSA = RSA.ExportParameters(true);

            string senhaRSA = Criptografia.criptografiaRSA(senha, parametrosRSA);
            Console.WriteLine("Criptografia usando RSA: " + senhaRSA + "\n");

            string senhaAES = Criptografia.criptografiaAES(senha, bytesChaves);
            Console.WriteLine("Criptografada usando AES: " + senhaAES + "\n");

            string senhaCriptografadaSHA2563 = Criptografia.CriptografiaSHA256(senha, chaveSecreta);
            Console.WriteLine("Criptografada usando SHA-256: " + senhaCriptografadaSHA2563 + "\n");

            Console.ReadKey();

        }
    }
}
