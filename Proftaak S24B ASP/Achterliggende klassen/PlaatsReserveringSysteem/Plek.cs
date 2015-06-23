﻿using System;
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

        public Plek(int id, int nummer, int capaciteit, int dagprijs, Locatie locatie)
        {
            this.ID = id;
            this.Nummer = nummer;
            this.Capaciteit = capaciteit;
            this.DagPrijs = dagprijs;
            this.Locatie = locatie;
        }

        public Plek(int nummer, int capaciteit, int dagprijs, Locatie locatie)
        {
            this.Nummer = nummer;
            this.Capaciteit = capaciteit;
            this.DagPrijs = dagprijs;
            this.Locatie = locatie;
        }

        public bool VoegToe()
        {
            DatabaseManager dm = new DatabaseManager();
            return dm.VoegPlekToe(this);
        }

        public bool Wijzig()
        {
            throw new NotImplementedException();
        }

        public bool Verwijder()
        {
            throw new NotImplementedException();
        }   
    }
}