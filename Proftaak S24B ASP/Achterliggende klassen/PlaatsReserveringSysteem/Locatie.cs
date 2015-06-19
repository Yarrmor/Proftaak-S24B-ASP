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

        public int NR { get; set; }

        public string Postcode { get; set; }

        public string Plaats { get; set; }

        public Locatie(int id, string naam, string straat, int nr, string postcode, string plaats)
        {
            this.ID = id;
            this.Naam = naam;
            this.Straat = straat;
            this.NR = nr;
            this.Postcode = postcode;
            this.Plaats = plaats;
        }

        public bool VoegToe()
        {
            throw new NotImplementedException();
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