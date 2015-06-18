using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proftaak_S24B_ASP
{
    public class Verhuur
    {
        public int ID { get; set; }

        public int ReserveringsPoolsbandjeID { get; set; }

        public DateTime DatumIn { get; set; }

        public DateTime DatumUit { get; set; }

        public int TotaalPrijs { get; set; }

        public bool Betaald { get; set; }

        public Exemplaar Exemplaar { get; set; }

        public Verhuur()
        {

        }

        public bool Huur()
        {
            throw new NotImplementedException();
        }

        public bool Wijzig()
        {
            throw new NotImplementedException();
        }

        public bool Annuleer() //Staat niet in klassendiagram maar denk dat deze methode hierbij wel nodig is.
        {
            throw new NotImplementedException();
        }

        public bool TerugGebracht()
        {
            throw new NotImplementedException();
        }
    }
}