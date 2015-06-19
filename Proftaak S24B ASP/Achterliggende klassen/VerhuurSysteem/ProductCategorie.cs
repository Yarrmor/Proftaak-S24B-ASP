using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proftaak_S24B_ASP
{
    public class ProductCategorie
    {
        public int ID { get; set; }

        public string Naam { get; set; }

        public ProductCategorie HoofdCategorie { get; set; }

        public ProductCategorie(int id, string naam)
        {
            ID = id;
            Naam = naam;
        }

        public ProductCategorie(int id, string naam, ProductCategorie hoofdCategorie)
        {
            ID = id;
            Naam = naam;
            HoofdCategorie = hoofdCategorie;
        }

        public List<ProductCategorie> VerkrijgSubCategorieen()
        {
            throw new NotImplementedException();
        }

        public List<Product> VerkrijgProducten()
        {
            throw new NotImplementedException();
        }
    }
}