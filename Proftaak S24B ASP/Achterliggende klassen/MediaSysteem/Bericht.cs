using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proftaak_S24B_ASP
{
    public class Bericht : Bijdrage
    {
        public Bijdrage HoofdBijdrage { get; set; }
        public string Titel { get; set; }
        public string Inhoud { get; set; }

        private DatabaseManager dm;

        public Bericht(int id, DateTime datum, Account account, Bijdrage hoofdBijdrage, string titel, string inhoud) 
            : base(id, datum, account) 
        {
            this.HoofdBijdrage = hoofdBijdrage;
            this.Titel = titel;
            this.Inhoud = inhoud;
	    }

        public List<Bericht> VerkrijgBerichten()
        {
            return dm.VerkrijgBerichten(this.ID);
        }
    }
}