using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAnaliseDeVendas.Entities
{
    internal class Sale
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public string Seller { get; set; }
        public int Items { get; set; }
        public double Total { get; set; }

        public Sale() { }
        public Sale(int month, int year, string seller, int items, double total)
        {
            Month = month;
            Year = year;
            Seller = seller;
            Items = items;
            Total = total;
        }

        //preço médio
        public double AveragePrice()
        {
            return Total / Items;
        }


    }
}
