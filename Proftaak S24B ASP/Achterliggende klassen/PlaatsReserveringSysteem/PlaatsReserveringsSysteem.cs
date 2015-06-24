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

        public static List<string>  VerkrijgPlekFilters(int eventID)
        {
            DatabaseManager dm = new DatabaseManager();
            return dm.VerkrijgAllePlekFilters(eventID);
        }

        public static List<Plek> VerkrijgPlekken(int eventID, Locatie l)
        {
            DatabaseManager dm = new DatabaseManager();
            return dm.VerkrijgPlekken(eventID, l);
        }

        public static bool ReserveerPlek(Plek p, Event evenement, int datumStartIndex, int datumEindIndex, string voornaam, string achternaam,
                                        int telefoonnummer, string woonplaats, string straatnaam, string huisnummer, string emailAdres,
                                        string bankrekeningnummer, int aantal, string email2, string email3, string email4, string email5, string email6,
                                        string email7, string email8)
        {
            DatabaseManager dm = new DatabaseManager();

            // Check capaciteit < aantal personen 

            // Verkrijg Persoon van banknr

            // geen persoon? maak aan

            // Verkrijg acc van email
            
            // geen acc? maak aan

            // verkrijg acc van email2 t/m email 8

            // maak groepleden accs voor ieder geldig email in email2 t/m email8 dat niet gebruikt is

            // maak reservering

            // maak plekreservering

            // haal geldige polsbandjes op

            // maak reservering_polsbandjes

        }
    }
}