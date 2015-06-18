using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proftaak_S24B_ASP
{
    public class PlaatsReservering
    {
        public int ID { get; set; }

        public DateTime DatumStart { get; set; }

        public DateTime DatumEind { get; set; }

        public bool Betaald { get; set; }

        public int Totaalprijs { get; set; }

        public Plek Plek { get; set; }

        public Persoon Persoon { get; set; }

        public PlaatsReservering()
        {

        }

        public bool Reserveer()
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