using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proftaak_S24B_ASP
{
    public class Exemplaar
    {
        public int ID { get; set; }

        public Product Product { get; set; }

        public int Volgnummer { get; set; }

        public string Barcode { get; set; }

        public bool Uitgeleend { get; set; }

        public Exemplaar()
        {

        }
        public bool Verwijder()
        {
            throw new NotImplementedException();
        }

        public bool VoegToe()
        {
            throw new NotImplementedException();
        }

        public bool Wijzig()
        {
            throw new NotImplementedException();
        }
    }
}