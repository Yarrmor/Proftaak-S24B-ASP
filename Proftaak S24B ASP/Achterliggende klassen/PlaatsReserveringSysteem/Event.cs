﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proftaak_S24B_ASP
{
    public class Event
    {
        public int ID { get; set; }

        public string Naam { get; set; }

        public DateTime DatumStart { get; set; }

        public DateTime DatumEind { get; set; }

        public Locatie Locatie { get; set; }

        public int MaxBezoekers { get; set; }

        public Event()
        {

        }

        public bool VoegToe()
        {
            throw new NotImplementedException();
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