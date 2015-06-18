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

        public Categorie HoofdCategorie { get; set; }

        public ProductCategorie()
        {

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