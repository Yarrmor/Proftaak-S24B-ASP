using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proftaak_S24B_ASP
{
    public class Locatie
    {
        public int ID { get; set; }

        public string Naam { get; set; }

        public string Straat { get; set; }

        public string HuisNR { get; set; }

        public string Postcode { get; set; }

        public string Plaats { get; set; }

        public Locatie(int id, string naam, string straat, string huisNR, string postcode, string plaats)
        {
            this.ID = id;
            this.Naam = naam;
            this.Straat = straat;
            this.HuisNR = huisNR;
            this.Postcode = postcode;
            this.Plaats = plaats;
        }

        //Voor nieuwe locaties, bij een nieuw locatie heb je geen id nodig, die worden gegenereert in de database.
        public Locatie(string naam, string straat, string huisNR, string postcode, string plaats)
        {
            this.Naam = naam;
            this.Straat = straat;
            this.HuisNR = huisNR;
            this.Postcode = postcode;
            this.Plaats = plaats;
        }

        public bool VoegToe()
        {
            DatabaseManager dm = new DatabaseManager();
            return dm.VoegLocatieToe(this);
        }

        public bool Wijzig()
        {
            throw new NotImplementedException();
        }

        public bool Verwijder()
        {
            throw new NotImplementedException();
        }
    }
}