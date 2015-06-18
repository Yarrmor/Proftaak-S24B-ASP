using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proftaak_S24B_ASP
{
    public class Bestand : Bijdrage
    {
        public string Naam { get; set; }

        public string BestandsLocatie { get; set; }

        public int Grootte { get; set; }

        public Categorie Categorie { get; set; }

        public Bestand(int ID, DateTime datum, Account account, Categorie categorie, string naam, string bestandsLocatie, int grootte) 
            : base(ID, datum, account) 
        {
            this.Naam = naam;
            this.BestandsLocatie = bestandsLocatie;
            this.Grootte = grootte;
            this.Categorie = categorie;
        }

        public void Download()
        {

        }

        public List<Bericht> VerkrijgBerichten()
        {
            throw new NotImplementedException();            
        }
    }
}