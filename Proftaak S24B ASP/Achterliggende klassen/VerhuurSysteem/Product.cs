using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proftaak_S24B_ASP
{
    public class Product
    {
        public int ID { get; set; }

        public ProductCategorie ProductCategorie { get; set; }

        public string Merk { get; set; }

        public string Serie { get; set;}

        public int Typenummer { get; set; }

        public int Prijs { get; set; }

        public Product()
        {

        }

        public bool Verwijder()
        {
            throw new NotImplementedException();
        }

        public bool VoegToe()
        {
            throw new NotImplementedException();
        }

        public bool Wijzig()
        {
            throw new NotImplementedException();
        }
    }
}