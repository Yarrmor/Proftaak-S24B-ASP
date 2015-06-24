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

        public string HuisNR { get; set; }

        public string Woonplaats { get; set; }

        public string BankNR { get; set; }

        public Persoon(string voornaam, string tussenvoegsel, string achternaam, string straat, string huisNR, string woonplaats, string bankNR)
        {
            Voornaam = voornaam;
            Tussenvoegsel = tussenvoegsel;
            Achternaam = achternaam;
            Straat = straat;
            HuisNR = huisNR;
            Woonplaats = woonplaats;
            BankNR = bankNR;
        }

        //Misschien nog een wijzig gegevens methode (OPTIONEEL)

        internal bool VoegToe()
        {
            DatabaseManager dm = new DatabaseManager();

            return dm.VoegPersoonToe(this);

        }
    }
}