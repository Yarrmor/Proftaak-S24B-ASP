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

        public Product(ProductCategorie productCategorie, string merk, string serie, int typenummer, int prijs)
        {
            ProductCategorie = productCategorie;
            Merk = merk;
            Serie = serie;
            Typenummer = typenummer;
            Prijs = prijs;
        }

        public Product(int id, ProductCategorie productCategorie, string merk, string serie, int typenummer, int prijs)
        {
            ID = id;
            ProductCategorie = productCategorie;
            Merk = merk;
            Serie = serie;
            Typenummer = typenummer;
            Prijs = prijs;
        }

        public bool Verwijder()
        {
            throw new NotImplementedException();
        }

        public bool VoegToe()
        {
            DatabaseManager dm = new DatabaseManager();
            return dm.VoegProductToe(this);
        }

        public bool Wijzig()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Probeert een exemplaar van dit product te huren
        /// </summary>
        /// <returns></returns>
        public bool Huur(Account a, Event evenement, DateTime beginDatum, DateTime eindDatum)
        {
            DatabaseManager dm = new DatabaseManager();

            return dm.HuurProduct(this, evenement, a, beginDatum, eindDatum);
        }
        public override string ToString()
        {
            return Merk + " - " + Serie + " - " + Typenummer;
        }
    }
}