using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proftaak_S24B_ASP
{
    public class BeheerSysteem
    {
        public BeheerSysteem()
        {

        }

        public List<ProductCategorie> VerkrijgProductCategorieen()
        {
            DatabaseManager dm = new DatabaseManager();
            return dm.VerkrijgAlleProductCategorieen();
        }

        public List<Product> VerkrijgProducten()
        {
            DatabaseManager dm = new DatabaseManager();
            return dm.VerkrijgAlleProducten();
        }

        public List<Verhuur> VerkrijgVerhuur()
        {
            throw new NotImplementedException();
        }

        public List<Verhuur> VerkrijgVerhuur(Product product) 
        {
            throw new NotImplementedException();
        }

        public List<PlaatsReservering> VerkrijgPlaatsReserveringen()
        {
            throw new NotImplementedException();
        }

        public List<Melding> VerkrijgMeldingen()
        {
            throw new NotImplementedException();
        }

        public List<string> VerkrijgFilters(int eventID)
        {
            DatabaseManager dm = new DatabaseManager();
            return dm.VerkrijgAllePlekFilters(eventID);
        }
    }
}