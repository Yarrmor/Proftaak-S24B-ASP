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
        public Bijdrage(int id, DateTime datum, Account account)
        {

        }

        public Bijdrage(int id)
        {
            this.ID = id;
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