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

        public Locatie()
        {

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