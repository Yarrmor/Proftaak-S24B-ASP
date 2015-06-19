using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Proftaak_S24B_ASP
{
    public class VerhuurSysteem
    {
        public DateTime BeginDatum { get; set; }
        public DateTime EindDatum { get; set; }

        public VerhuurSysteem()
        {

        }

        /// <summary>
        /// Retourneert voor iedere dag van het evenement een datetime in een list.
        /// Ook wordt BeginDatum en EindDatum op de juiste waarde gezet.
        /// </summary>
        /// <param name="evenement"></param>
        /// <returns></returns>
        public List<DateTime> VerkrijgDatums(Event evenement)
        {
            DatabaseManager dm = new DatabaseManager();

            List<DateTime> datums = dm.VerkrijgDatums(evenement.ID);

            BeginDatum = datums[0];
            EindDatum = datums[datums.Count - 1];

            return datums;
        }

        /// <summary>
        /// Retourneert een juist opgestelde treeview met als childs de naam van alle categorieen en de onderliggende namen van categorieen
        /// </summary>
        /// <returns></returns>
        public TreeNodeCollection VerkrijgProductCategorieen()
        {
            DatabaseManager dm = new DatabaseManager();

            TreeNodeCollection tnc = new TreeNodeCollection();

            // Haalt alle hoofdcategorieen op
            List<ProductCategorie> productCategorieen = dm.VerkrijgProductCategorieen();

            // Voor iedere hoofdcategorie, maak een node aan en voeg deze na het toevoegen van alle child nodes van die categorie toe aan de treeview
            foreach (ProductCategorie pcat in productCategorieen)
            {
                TreeNode node = new TreeNode(pcat.Naam);

                node = VerkrijgProductCategorieen(node, pcat);

                tnc.Add(node);
            }

            return tnc;
        }

        /// <summary>
        /// Haalt de onderliggende categorieen op van hoofdPCat en voegt deze toe aan de meegegeven hoofdNode.
        /// Methode retourneert de aangepaste meegegeven hoofdNode.
        /// </summary>
        /// <param name="hoofdNode"></param>
        /// <param name="hoofdPCat"></param>
        /// <returns></returns>
        public TreeNode VerkrijgProductCategorieen(TreeNode hoofdNode, ProductCategorie hoofdPCat)
        {
            DatabaseManager dm = new DatabaseManager();

            // Haalt alle onderliggende categorieen toe van de meegegeven categorie
            List<ProductCategorie> productCategorieen = dm.VerkrijgProductCategorieen(hoofdPCat);

            // Voor iedere onderliggende categorie, voeg deze toe aan de hoofdNode en roep deze zelfde methode op voor iedere onderliggende categorie
            // Zo zullen alle subcategorieen worden opgehaald tot er geen subcategorieen meer gevonden zijn.
            foreach (ProductCategorie pcat in productCategorieen)
            {
                TreeNode node = new TreeNode(pcat.Naam);

                node = VerkrijgProductCategorieen(node, pcat);

                hoofdNode.ChildNodes.Add(node);
            }

            return hoofdNode;
        }

        public ProductCategorie VerkrijgProductCategorie(string naam)
        {
            DatabaseManager dm = new DatabaseManager();

            return dm.VerkrijgProductCategorie(naam);
        }

        public List<Product> VerkrijgProducten(ProductCategorie pcat)
        {
            DatabaseManager dm = new DatabaseManager();

            List<Product> producten = dm.VerkrijgProducten(pcat);

            var session = HttpContext.Current.Session;

            session["Producten"] = producten;

            return producten;
        }

        public bool HuurProduct(Product p, Account a, int datumStartIndex, int datumEindIndex)
        {
            DatabaseManager dm = new DatabaseManager();

            // Zet datum indexes om naar daadwerkelijke datums van evenement
            var session = HttpContext.Current.Session;

            Event evenement = session["SelectedEvent"] as Event;

            List<DateTime> datums = dm.VerkrijgDatums(evenement.ID);

            DateTime beginDatum = datums[datumStartIndex];
            DateTime eindDatum = datums[datumStartIndex + datumEindIndex];

            return p.Huur(a, evenement, beginDatum, eindDatum);
        }

    }
}