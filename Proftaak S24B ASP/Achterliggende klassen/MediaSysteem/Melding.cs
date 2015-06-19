using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proftaak_S24B_ASP
{
    public class Melding
    {
        public int ID { get; set; }
        public DateTime Datum { get; set; }
        public string Beschrijving { get; set; }
        public Account Account { get; set; }
        public Bijdrage Bijdrage { get; set; }

        public Melding(int id, Bijdrage bijdrage, Account account, DateTime datum, string beschrijving)
        {
            this.ID = id;
            this.Bijdrage = bijdrage;
            this.Account = account;
            this.Datum = datum;
            this.Beschrijving = beschrijving;
        }

        public bool Meld()
        {
            throw new NotImplementedException();            
        }
    }
}