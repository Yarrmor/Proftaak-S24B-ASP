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

        private DatabaseManager dm;

        public Bestand(int id, DateTime datum, Account account, Categorie categorie, string naam, string bestandsLocatie, int grootte)
            :base(id, datum, account)
        {
            this.Naam = naam;
            this.BestandsLocatie = bestandsLocatie;
            this.Grootte = grootte;
            this.Categorie = categorie;
        }

        public override bool VoegToe()
        {
            //return this.dm.VoegToe(this);
            return false;
        }

        public override bool Verwijder()
        {
            //return this.dm.Verwijder(this.ID);
            return false;
        }

        public void Download()
        {

        }

        public List<Bericht> VerkrijgBerichten()
        {
            this.dm = new DatabaseManager();

            return this.dm.VerkrijgBerichten(this.ID);
        }
    }
}