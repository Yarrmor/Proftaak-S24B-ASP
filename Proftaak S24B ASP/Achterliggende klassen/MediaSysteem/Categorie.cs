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

        private DatabaseManager dm;

        public Categorie(int id, DateTime datum, Account account, string naam) 
            : base(id, datum, account)
        {
            this.Naam = naam;
        }

        public Categorie(int id, DateTime datum, Account account, string naam, Categorie hoofdCategorie)
            : base(id, datum, account)
        {
            this.Naam = naam;
            this.HoofdCategorie = hoofdCategorie;
        }

        public Categorie(int id, string naam)
            :base(id)
        {
            this.Naam = naam;
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

        public List<Bericht> VerkrijgBerichten()
        {
            throw new NotImplementedException();            
        }
    }
}