using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proftaak_S24B_ASP
{
    public class Bijdrage
    {
        public int ID { get; set; }

        public DateTime Datum { get; set; }

        public Account Account { get; set; }
        

        //Verbeteren in klassediagram
        public Bijdrage(int ID, DateTime datum, Account account)
        {

        }

        public bool VoegToe()
        {
            throw new NotImplementedException();            
        }

        public bool Verwijder()
        {
            throw new NotImplementedException();
        }
    }
}