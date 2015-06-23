using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Proftaak_S24B_ASP
{
    public class MediaSysteem
    {
        public List<Bestand> Bestanden { get; set; }
        public List<Categorie> Categorieën { get; set; }
        public Bestand Bestand { get; set; }
        public List<Bericht> Berichten { get; set; }
        public Bericht Bericht { get; set; }

        private DatabaseManager dm = new DatabaseManager();

        public List<Categorie> VerkrijgCategorieen()
        {
            this.Categorieën = this.dm.VerkrijgCategorieen();
            return this.Categorieën;
        }

        public List<Categorie> VerkrijgCategorieen(Categorie cat)
        {
            this.Categorieën = this.dm.VerkrijgCategorieen(cat);
            return this.Categorieën;
        }

        public Categorie VerkrijgCategorie(string naam)
        {
            return this.dm.VerkrijgCategorie(naam);
        }

        public Bestand VerkrijgBestand(int id)
        {
            this.Bestand = this.dm.VerkrijgBestand(id);
            return null;
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
            return false; //this.dm.PlaatsBericht(hoofdBericht, titel, bericht);
        }

        public bool PlaatsBericht(string titel, string bericht)
        {
            return false; //this.dm.PlaatsBericht(titel, bericht);
        }

        public TreeNodeCollection VulSubMenu()
        {
            TreeNodeCollection tnc = new TreeNodeCollection();
            List<Categorie> hoofdCatList = VerkrijgCategorieen();

            foreach(Categorie hoofdCat in hoofdCatList)
            {
                TreeNode tn = new TreeNode(hoofdCat.Naam);
                tn = VulSubCat(hoofdCat, tn);
                tnc.Add(tn);
            }
            return tnc;
        }

        public TreeNode VulSubCat(Categorie cat, TreeNode parent)
        {
            List<Categorie> subCatList = VerkrijgCategorieen(cat);
            foreach(Categorie subCat in subCatList)
            {
                TreeNode tn = new TreeNode(subCat.Naam);
                tn = VulSubCat(subCat, tn);
                parent.ChildNodes.Add(tn);
            }
            return parent;
        }
    }
}