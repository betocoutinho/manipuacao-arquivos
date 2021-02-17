using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;

namespace arquivos
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<string> lista1 = new List<string>();
                List<string> lista2 = new List<string>();

                string arquivo = @"C:\temp\itensvendidos.csv";

                //Leitura
                using (StreamReader sr = File.OpenText(arquivo))
                {
                    while (!sr.EndOfStream)
                    {
                        lista1.Add(sr.ReadLine());
                    }
                }

                //processamento

                foreach (var item in lista1)
                {
                    string[] temp = item.Split(",");

                    double valor = double.Parse(temp[1], CultureInfo.InvariantCulture);
                    double quant = double.Parse(temp[2], CultureInfo.InvariantCulture);

                    double total = valor *quant;

                    string result = temp[0] + "," + total;

                    lista2.Add(result);


                }

                //saida

                string novaPasta = Path.GetDirectoryName(arquivo) + @"\out";
                Directory.CreateDirectory(novaPasta);

                string novoArquivo = novaPasta + @"\summary.csv";

                using (StreamWriter sw = File.CreateText(novoArquivo))
                {
                    foreach (var item in lista2)
                    {
                        sw.WriteLine(item);
                    }
                }




            }
            catch (IOException e)
            {

                Console.WriteLine("Um erro ocorreu: ");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }

       
    }
}
