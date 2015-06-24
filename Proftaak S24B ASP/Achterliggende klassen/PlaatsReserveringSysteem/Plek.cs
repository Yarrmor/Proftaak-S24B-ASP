using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proftaak_S24B_ASP
{
    public class Plek
    {
        public int ID { get; set; }

        public int Nummer { get; set; }

        public int Capaciteit { get; set; }

        public int DagPrijs { get; set; }

        public Locatie Locatie { get; set; }

        public List<string> Filters { get; set; }

        public Plek(int id, int nummer, int capaciteit, int dagprijs, Locatie locatie, List<string> filters)
        {
            this.ID = id;
            this.Nummer = nummer;
            this.Capaciteit = capaciteit;
            this.DagPrijs = dagprijs;
            this.Locatie = locatie;
            Filters = filters;
        }

        public Plek(int nummer, int capaciteit, int dagprijs, Locatie locatie, List<string> filters)
        {
            this.Nummer = nummer;
            this.Capaciteit = capaciteit;
            this.DagPrijs = dagprijs;
            this.Locatie = locatie;
            Filters = filters;
        }

        public bool VoegToe()
        {
            DatabaseManager dm = new DatabaseManager();
            return dm.VoegPlekToe(this);
        }

        public bool Wijzig()
        {
            DatabaseManager dm = new DatabaseManager();
            return dm.WijzigPlek(this);
        }

        public bool Verwijder()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return ID.ToString() + "-" + Locatie.Naam + "-" + Nummer.ToString();
        }
    }
}