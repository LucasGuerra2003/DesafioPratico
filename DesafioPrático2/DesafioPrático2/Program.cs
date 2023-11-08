using System;
using System.IO;

namespace Aniversariantes
{
    class Program
    {
        static void Main(string[] args)
        {
            string arqniver = "datasnascimento.txt";
            int mesAtual = DateTime.Today.Month;
            string arqnivermes = "C:\\AniversárioConsultores"+mesAtual+".txt";
            string linha = "";

            StreamReader sr = new StreamReader(arqniver);
            StreamWriter sw = new StreamWriter(arqnivermes);
            do
            {
                string[] campos = linha.Split('|');
                if (campos.Length >= 3 && DateTime.TryParse(campos[2].Trim(), out DateTime dataNascimento))
                {
                    if (dataNascimento.Month == mesAtual)
                    {
                        sw.WriteLine(linha);
                    }
                }
            } while ((linha = sr.ReadLine()) != null);
            sw.Close();

        }
    }
}
