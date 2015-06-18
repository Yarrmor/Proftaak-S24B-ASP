using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proftaak_S24B_ASP
{
    public class Plek
    {
        public int ID { get; set; }

        public int Nummer { get; set; }

        public int Capaciteit { get; set; }

        public int DagPrijs { get; set; }

        public Locatie Locatie { get; set; }

        public Plek()
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