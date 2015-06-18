using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proftaak_S24B_ASP
{
    public class MediaSysteem
    {
        public List<Bestand> Bestanden { get; set; }
        public List<Categorie> Categorieën { get; set; }
        public Bestand Bestand { get; set; }

        //private DatabaseManager dm;

        public List<Categorie> VerkrijgCategorieën()
        {
            return null;
        }

        public List<Categorie> VerkrijgCategorieën(Categorie cat)
        {
            return null;
        }

        public Categorie VerkrijgCategorie(string naam)
        {
            return null;
        }

        public List<Bestand> VerkrijgBestanden()
        {
            return null;
        }

        public List<Bestand> VerkrijgBestanden(Categorie cat)
        {
            return null;
        }
    }
}