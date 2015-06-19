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

        private DatabaseManager dm;

        //Verbeteren in klassediagram
        public Bijdrage(int id, DateTime datum, Account account)
        {
            this.ID = id;
            this.Datum = datum;
            this.Account = account;
        }

        public Bijdrage(int id)
        {
            this.ID = id;
        }

        public abstract bool VoegToe();

        public abstract bool Verwijder();
    }
}