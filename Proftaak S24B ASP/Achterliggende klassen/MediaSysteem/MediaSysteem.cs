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
        public List<Bericht> Berichten { get; set; }
        public Bericht Bericht { get; set; }

        private DatabaseManager dm;

        public List<Categorie> VerkrijgCategorieën()
        {
            this.Categorieën = this.dm.VerkrijgCategorieën();
            return this.Categorieën;
        }

        public List<Categorie> VerkrijgCategorieën(Categorie cat)
        {
            this.Categorieën = this.dm.VerkrijgCategorieën(cat);
            return this.Categorieën;
        }

        public Categorie VerkrijgCategorie(string naam)
        {
            this.Categorie = this.dm.VerkrijgCategorie(naam);
            return this.Categorie;
        }

        public List<Bestand> VerkrijgBestanden()
        {
            this.Bestanden = this.dm.VerkrijgBestanden();
            return this.Bestanden;
        }

        public List<Bestand> VerkrijgBestanden(Categorie cat)
        {
            this.Bestanden = this.dm.VerkrijgBestanden(cat);
            return this.Bestanden;
        }

        public bool PlaatsBericht(Bericht hoofdBericht, string titel, string bericht)
        {
            return this.dm.PlaatsBericht(hoofdBericht, titel, bericht);
        }

        public bool PlaatsBericht(string titel, string bericht)
        {
            return this.dm.PlaatsBericht(titel, bericht);
        }
    }
}