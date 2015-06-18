using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proftaak_S24B_ASP
{
    public class Bericht : Bijdrage
    {
        public string Titel { get; set; }

        public string Inhoud { get; set; }

        //int ID, DateTime datum, Account account
        public Bericht(int ID, DateTime datum, Account account, Bijdrage HoofdBijdrage, string Titel, string Inhoud) 
            : base(ID, datum, account) 
        {

        }

        public List<Bericht> VerkrijgBerichten()
        {
            throw new NotImplementedException();            
        }
    }
}