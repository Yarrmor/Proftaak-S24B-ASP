using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proftaak_S24B_ASP
{
    public class Categorie: Bijdrage
    {
        public string Naam { get; set; }

        public Categorie HoofdCategorie { get; set; }

        public Categorie(int ID, DateTime datum, Account account, string naam) 
            : base(ID, datum, account) 
        {

        }

        public Categorie(int ID, DateTime datum, Account account, string naam, Categorie HoofdCategorie)
            : base(ID, datum, account)
        {

        }

        public List<Bericht> VerkrijgBerichten()
        {
            throw new NotImplementedException();            
        }
    }
}