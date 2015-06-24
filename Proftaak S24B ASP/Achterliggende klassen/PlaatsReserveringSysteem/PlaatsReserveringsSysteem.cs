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
    }
}