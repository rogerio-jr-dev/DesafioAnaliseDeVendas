using DesafioAnaliseDeVendas.Entities;
using System.IO;
using System;
using System.Globalization;

namespace Desafio
{
    class Program
    {
        static void Main(string[] args)
        {

            CultureInfo CI = CultureInfo.InvariantCulture;

            Console.Write("Entre o caminho do arquivo: ");
            string path = Console.ReadLine();
            Console.WriteLine();//Pular linha

            List<Sale> list = new List<Sale>();

            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] fields = sr.ReadLine().Split(',');

                        int month = int.Parse(fields[0]);
                        int year = int.Parse(fields[1]);
                        string seller = fields[2];
                        int items = int.Parse(fields[3]);
                        double total = double.Parse(fields[4], CI);

                        list.Add(new Sale(month, year, seller, items, total));
                    }
                }

                Console.WriteLine("Cinco primeiras vendas de 2016 de maior preço médio ");

                var vendas2016 = list.Where(s => s.Year == 2016);

                var vendasOrdenadas = vendas2016.OrderByDescending(s => s.AveragePrice()).Take(5).ToList();

                var totalLogan = list.Where(s => s.Seller == "Logan" && (s.Month == 1 || s.Month == 7)).Sum(s => s.Total);


                foreach (var venda in vendasOrdenadas)
                {
                    Console.WriteLine(
                        venda.Month
                        + "/"
                        + venda.Year
                        + ", "
                        + venda.Seller
                        + ", "
                        + venda.Items
                        + ", "
                        + venda.Total.ToString("F2", CI)
                        + " pm = "
                        + venda.AveragePrice().ToString("F2", CI));
                }

                Console.WriteLine();//Pular linha 
                Console.WriteLine("Valor total vendido pelo vendedor Logan nos meses 1 e 7 = {0}", totalLogan.ToString("F2", CI));

            }
            catch (Exception e)
            {
                Console.Write("O sistema não pode encontrar o arquivo especificado ");
                Console.WriteLine(e.Message);
            }
        }
    }
}