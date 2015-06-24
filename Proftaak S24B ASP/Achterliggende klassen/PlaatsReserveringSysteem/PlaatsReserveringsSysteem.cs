using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proftaak_S24B_ASP
{
    public class PlaatsReserveringsSysteem
    {
        public PlaatsReserveringsSysteem()
        {

        }

        public List<Plek> VerkrijgBeschikbarePlekken(int eventID)
        {
            throw new NotImplementedException();
        }

        public List<Plek> VerkrijgBeschikbarePlekken(int eventID, List<Specificatie> specificaties)
        {
            throw new NotImplementedException();
        }

        public List<Specificatie> VerkrijgSpecificaties()
        {
            throw new NotImplementedException();
        }

        public Plek HaalPlekOp(int plekID)
        {
            throw new NotImplementedException();
        }

        public static List<DateTime> VerkrijgDatums(int eventID)
        {
            DatabaseManager dm = new DatabaseManager();
            return dm.VerkrijgDatums(eventID);
        }

        public static List<string>  VerkrijgPlekFilters()
        {
            DatabaseManager dm = new DatabaseManager();
            return dm.VerkrijgAllePlekFilters();
        }

        public static List<Plek> VerkrijgPlekken(int eventID, Locatie l)
        {
            DatabaseManager dm = new DatabaseManager();
            return dm.VerkrijgPlekken(eventID, l);
        }

        public static bool ReserveerPlek(Plek p, Event evenement, int datumStartIndex, int datumEindIndex, string voornaam, string tussenvoegsel, string achternaam,
                                        int telefoonnummer, string woonplaats, string straatnaam, string huisnummer, string emailAdres,
                                        string bankrekeningnummer, int aantal, string email2, string email3, string email4, string email5, string email6,
                                        string email7, string email8)
        {
            DatabaseManager dm = new DatabaseManager();

            throw new NotImplementedException();

            // Verkrijg Persoon van banknr
            if (!dm.BestaatPersoon(bankrekeningnummer))
            {
                // geen persoon? maak aan
                Persoon persoon = new Persoon(voornaam, tussenvoegsel, achternaam, straatnaam, huisnummer, woonplaats, bankrekeningnummer);
                if (!persoon.VoegToe())
                    return false;
            }

            if (!dm.BestaatAccount(emailAdres))
            {
                // geen account? maak aan
                //Account acc = new Account(emailAdres);

                //acc.VoegToe();
            }

            List<string> emails = new List<string>() { email2, email3, email4, email5, email6, email7, email8 };

            for (int i = 0; i < aantal - 1; i++)
            {
                string email = emails[i];

                if (!dm.BestaatAccount(email))
                {
                    // geen account? maak aan
                    //Account lidAccount = new Account(email);

                    //lidAccount.VoegToe();
                }
            }

            // maak reservering

            // maak plekreservering

            // haal geldige polsbandjes op

            // maak reservering_polsbandjes

            return false;
        }
    }
}