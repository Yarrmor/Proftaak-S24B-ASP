using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proftaak_S24B_ASP
{
    public class Account
    {
        public int ID { get; set; }

        public string Gebruikersnaam { get; set; }

        public string Email { get; set; }

        public bool Geactiveerd { get; set; }

        public Account(int ID, string gebruikersnaam)
        {

        }

        public Account(int ID, string gebruikersnaam, string email, bool geactiveerd)
        {

        }
    }
}