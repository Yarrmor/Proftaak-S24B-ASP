using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proftaak_S24B_ASP
{
    public class Persoon
    {
        public int ID { get; set; }

        public string Voornaam { get; set; }

        public string Tussenvoegsel { get; set; }

        public string Achternaam { get; set; }

        public string Straat { get; set; }

        public int HuisNR { get; set; }

        public string Woonplaats { get; set; }

        public int BankNR { get; set; }

        public Persoon()
        {

        }

        //Misschien nog een wijzig gegevens methode (OPTIONEEL)
    }
}