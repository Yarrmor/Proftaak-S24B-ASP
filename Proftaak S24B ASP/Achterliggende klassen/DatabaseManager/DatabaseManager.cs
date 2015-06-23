using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Proftaak_S24B_ASP
{
    public class DatabaseManager
    {
        string pcn = "dbi255847";
        string wachtwoord = "u1eoeVfvUI";

        OracleConnection verbinding;

        public DatabaseManager()
        {
            verbinding = new OracleConnection();

            verbinding.ConnectionString = "User Id=" + pcn + ";Password=" + wachtwoord + ";Data Source=" + "//192.168.15.50:1521/fhictora;";

            // Testen of dm werkt
            /*
            OracleCommand command = MaakOracleCommand("SELECT * FROM DUAL");

            OracleDataReader reader = VoerQueryUit(command);

            string s = reader[0].ToString();
            */
        }

        /// <summary>
        /// Retourneert een instantie van OracleCommand met
        /// this.Verbinding & .CommandType.Text
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public OracleCommand MaakOracleCommand(string sql)
        {
            OracleCommand command = new OracleCommand(sql, verbinding);
            command.CommandType = System.Data.CommandType.Text;

            return command;
        }

        /// <summary>
        /// Voert de query uit van meegegeven OracleCommand.
        /// Deze OracleCommand moet gemaakt zijn door MaakOracleCommand() en parameters moeten al ingesteld zijn.
        /// De teruggegeven lijst bevat voor elke rij een OracleDataReader.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public OracleDataReader VoerMultiQueryUit(OracleCommand command)
        {
            try
            {
                if (verbinding.State == ConnectionState.Closed)
                {
                    verbinding.Open();
                }

                OracleDataReader reader = command.ExecuteReader();

                return reader;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Voert de query uit van meegegeven OracleCommand.
        /// Deze OracleCommand moet gemaakt zijn door MaakOracleCommand() en parameters moeten al ingesteld zijn.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public OracleDataReader VoerQueryUit(OracleCommand command)
        {
            try
            {
                if (verbinding.State == ConnectionState.Closed)
                {
                    verbinding.Open();
                }

                OracleDataReader reader = command.ExecuteReader();

                reader.Read();

                return reader;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Voert de query uit van meegegeven OracleCommand
        /// Deze OracleCommand moet gemaakt zijn door MaakOracleCommand() en parameters moeten al ingesteld zijn.
        /// De output is of de query gelukt is.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public bool VoerNonQueryUit(OracleCommand command)
        {
            try
            {
                if (verbinding.State == ConnectionState.Closed)
                {
                    verbinding.Open();
                }

                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }


        ////
        // Queries
        ////

        #region Queries

        /// <summary>
        /// Retourneert voor iedere dag gedurende het evenement met ID eventID een DateTime.
        /// </summary>
        /// <param name="eventID"></param>
        /// <returns></returns>
        public List<DateTime> VerkrijgDatums(int eventID)
        {
            try
            {
                string sql = "SELECT DATUMSTART, DATUMEINDE FROM EVENT WHERE ID = :EVENTID";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":EVENTID", eventID);

                OracleDataReader reader = VoerQueryUit(command);

                List<DateTime> dates = new List<DateTime>();

                DateTime datumStart = Convert.ToDateTime(reader["DATUMSTART"]);
                DateTime datumEind = Convert.ToDateTime(reader["DATUMEINDE"]);

                do
                {
                    dates.Add(datumStart);
                    datumStart = datumStart.AddDays(1);
                } while (datumStart.Date != datumEind);

                return dates;
            }
            catch
            {
                return null;
            }
            finally
            {
                verbinding.Close();
            }  
        }

        public List<DateTime> VerkrijgDatums(Event evenement)
        {
            List<DateTime> dates = new List<DateTime>();

            DateTime datumStart = evenement.DatumStart;
            DateTime datumEind = evenement.DatumEind;

            do
            {
                dates.Add(datumStart);
                datumStart = datumStart.AddDays(1);
            } while (datumStart.Date != datumEind);

            return dates;
        }

        #region Queries/Account
        /// <summary>
        /// Verkrijg een account voor het gegeven email en wachtwoord.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="wachtwoord"></param>
        /// <returns></returns>
        public Account VerkrijgAccount(string email, string wachtwoord)
        {
            try
            {
                string sql = "SELECT ID, GEBRUIKERSNAAM, GEACTIVEERD FROM ACCOUNT WHERE EMAIL = :email AND WACHTWOORD = :wachtwoord";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":email", email);
                command.Parameters.Add(":wachtwoord", wachtwoord);

                OracleDataReader reader = VoerQueryUit(command);

                int ID = Convert.ToInt32(reader["ID"]);
                string gebruikersnaam = reader["GEBRUIKERSNAAM"].ToString();
                bool geactiveerd = Convert.ToBoolean(reader["GEACTIVEERD"]);

                Account acc = new Account(ID, gebruikersnaam, email, geactiveerd);

                return acc;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Verkrijgt een account op basis van de activatieHash
        /// </summary>
        /// <param name="activatieHash"></param>
        /// <returns></returns>
        public Account VerkrijgAccount(string activatieHash)
        {
            try
            {
                string sql = "SELECT ID, GEBRUIKERSNAAM, EMAIL, GEACTIVEERD FROM ACCOUNT WHERE ACTIVATIEHASH = :activatieHash";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":activatieHash", activatieHash);

                OracleDataReader reader = VoerQueryUit(command);

                int ID = Convert.ToInt32(reader["ID"]);
                string email = reader["EMAIL"].ToString();
                string gebruikersnaam = reader["GEBRUIKERSNAAM"].ToString();
                bool geactiveerd = Convert.ToBoolean(reader["GEACTIVEERD"]);

                Account acc = new Account(ID, gebruikersnaam, email, geactiveerd);

                return acc;
            }
            catch
            {
                return null;
            }
        }


        public bool ActiveerAccount(int accountID, string gebruikersNaam, string wachtwoordHash)
        {
            try
            {
                //"UPDATE ACCOUNT SET GEBRUIKERSNAAM = :gebruikersnaam , WACHTWOORD = :wachtwoord WHERE ID = :ID"
                string sql = "UPDATE ACCOUNT SET GEBRUIKERSNAAM = :gebruikersnaam , WACHTWOORD = :wachtwoord, GEACTIVEERD = 1 WHERE ID = :ID";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":gebruikersnaam", gebruikersNaam);
                command.Parameters.Add(":wachtwoord", wachtwoordHash);
                command.Parameters.Add(":ID", accountID);

                return VoerNonQueryUit(command);
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Queries/MateriaalReservering

        /// <summary>
        /// Haalt alle productcategorieen op die geen hoofdcategorie hebben (fk is null)
        /// </summary>
        /// <returns></returns>
        public List<ProductCategorie> VerkrijgProductCategorieen()
        {
            try
            {
                string sql = "SELECT ID, NAAM FROM PRODUCTCAT WHERE PRODUCTCAT_ID IS NULL";

                OracleCommand command = MaakOracleCommand(sql);

                OracleDataReader reader = VoerMultiQueryUit(command);

                List<ProductCategorie> categorieen = new List<ProductCategorie>();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["ID"]);
                    string naam = reader["NAAM"].ToString();

                    categorieen.Add(new ProductCategorie(id, naam));
                }

                return categorieen;
            }
            catch
            {
                return null;
            }
            finally
            {
                verbinding.Close();
            }
        }

        /// <summary>
        /// Haalt alle productcategorieen op die als hoofdcategorie de meegegeven categorie hebben (gebaseerd op ID)
        /// </summary>
        /// <param name="hoofdCategorie"></param>
        /// <returns></returns>
        public List<ProductCategorie> VerkrijgProductCategorieen(ProductCategorie hoofdCategorie)
        {
            try
            {
                string sql = "SELECT ID, NAAM FROM PRODUCTCAT WHERE PRODUCTCAT_ID = :PCATID";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":PCATID", hoofdCategorie.ID);

                OracleDataReader reader = VoerMultiQueryUit(command);

                List<ProductCategorie> productCategorieen = new List<ProductCategorie>();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["ID"]);
                    string naam = reader["NAAM"].ToString();

                    productCategorieen.Add(new ProductCategorie(id, naam));
                }

                return productCategorieen;
            }
            catch
            {
                return null;
            }
            finally
            {
                verbinding.Close();
            }
        }

        /// <summary>
        /// Haalt de gegevens van de productcategorie op met deze naam
        /// Wordt gebruikt om ID van productCategorie op te halen als je alleen naam weet (bv in treeview)
        /// </summary>
        /// <param name="naam"></param>
        /// <returns></returns>
        public ProductCategorie VerkrijgProductCategorie(string naam)
        {
            try
            {
                string sql = "SELECT ID, NAAM FROM PRODUCTCAT WHERE UPPER(NAAM) = :PCNAAM";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":PCNAAM", naam.ToUpper());

                OracleDataReader reader = VoerQueryUit(command);

                int id = Convert.ToInt32(reader["ID"]);
                string catNaam = reader["NAAM"].ToString();

                return new ProductCategorie(id, catNaam);
            }
            catch
            {
                return null;
            }
            finally
            {
                verbinding.Close();
            }
        }

        /// <summary>
        /// Retourneert een lijst met producten waarvan exemplaren beschikbaar zijn om uitgeleend te worden, binnen de meegegeven productcategorie
        /// </summary>
        /// <param name="pcat"></param>
        /// <returns></returns>
        public List<Product> VerkrijgProducten(ProductCategorie pcat)
        {
            try
            {
                string sql = "SELECT ID, MERK, SERIE, TYPENUMMER, PRIJS FROM PRODUCT WHERE PRODUCTCAT_ID = :PCATID AND ID IN ( SELECT PRODUCT_ID FROM PRODUCTEXEMPLAAR WHERE ID NOT IN ( SELECT PRODUCTEXEMPLAAR_ID FROM VERHUUR WHERE SYSDATE <= DATUMIN))";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":PCATID", pcat.ID);

                OracleDataReader reader = VoerMultiQueryUit(command);

                List<Product> producten = new List<Product>();

                while (reader.Read())
	            {
	                int id = Convert.ToInt32(reader["ID"]);
                    string merk = reader["MERK"].ToString();
                    string serie = reader["SERIE"].ToString();
                    int typeNummer = Convert.ToInt32(reader["TYPENUMMER"]);
                    int prijs = Convert.ToInt32(reader["PRIJS"]);

                    Product p = new Product(id, pcat, merk, serie, typeNummer, prijs);
                    producten.Add(p);

	            }

                return producten;
                
            }
            catch
            {
                return null;
            }
            finally
            {
                verbinding.Close();
            }
        }

        public bool HuurProduct(Product p, Event evenement, Account a, DateTime beginDatum, DateTime eindDatum)
        {
            try
            {
                // Zoek beschikbaar exemplaarID
                int exemplaarID = VerkrijgVerhuurbaarExemplaarID(p);
                if (exemplaarID == -1)
                    return false;

                // Zoek polsbandje_id van account voor huidige evenement
                int polsbandjeID = VerkrijgPolsbandjeID(a, evenement);
                if (polsbandjeID == -1)
                    return false;

                // Insert de gegevens in verhuur
                string sql = "INSERT INTO VERHUUR (PRODUCTEXEMPLAAR_ID, RES_PB_ID, DATUMIN, DATUMUIT, BETAALD) VALUES (:EXEMPLAARID, :PB_ID, :DATUMIN, :DATUMUIT, 0)";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":EXEMPLAARID", exemplaarID);
                command.Parameters.Add(":PB_ID", polsbandjeID);
                command.Parameters.Add(":DATUMIN", eindDatum);
                command.Parameters.Add(":DATUMUIT", beginDatum);

                return VoerNonQueryUit(command);
            }
            catch
            {
                return false;
            }
            finally
            {
                verbinding.Close();
            }
        }

        /// <summary>
        /// Haalt het polsbandje id op van de meegegeven account voor het meegegeven evenement.
        /// </summary>
        /// <param name="account"></param>
        /// <param name="evenement"></param>
        /// <returns></returns>
        public int VerkrijgPolsbandjeID(Account account, Event evenement)
        {
            try
            {
                string sql = "SELECT POLSBANDJE_ID AS PBID FROM RESERVERING_POLSBANDJE WHERE ACCOUNT_ID = :ACCID AND RESERVERING_ID IN ( SELECT ID FROM RESERVERING WHERE ID IN ( SELECT RESERVERING_ID FROM PLEK_RESERVERING WHERE PLEK_ID IN ( SELECT ID FROM PLEK WHERE LOCATIE_ID IN ( SELECT LOCATIE_ID FROM EVENT WHERE ID = :EVENTID))))";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":ACCID", account.ID);
                command.Parameters.Add(":EVENTID", evenement.ID);

                OracleDataReader reader = VoerQueryUit(command);

                return Convert.ToInt32(reader["PBID"]);
            }
            catch
            {
                return -1;
            }
            finally
            {
                verbinding.Close();
            }
        }

        public int VerkrijgVerhuurbaarExemplaarID(Product p)
        {
            try
            {
                string sql = "SELECT ID FROM PRODUCTEXEMPLAAR WHERE ID NOT IN ( SELECT PRODUCTEXEMPLAAR_ID FROM VERHUUR WHERE SYSDATE <= DATUMIN) AND PRODUCT_ID = :PID AND ROWNUM <= 1";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":PID", p.ID);

                OracleDataReader reader = VoerQueryUit(command);

                return Convert.ToInt32(reader["ID"]);
            }
            catch
            {
                return -1;
            }
            finally
            {
                verbinding.Close();
            }
        }

        #endregion

        #region Queries/Media

        public List<Categorie> VerkrijgCategorieen()
        {
            try
            {
                string sql = "SELECT BIJDRAGE_ID, NAAM FROM CATEGORIE WHERE CATEGORIE_ID IS NULL";

                OracleCommand command = MaakOracleCommand(sql);

                OracleDataReader reader = VoerMultiQueryUit(command);

                List<Categorie> categorieen = new List<Categorie>();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["BIJDRAGE_ID"]);
                    string naam = reader["NAAM"].ToString();

                    categorieen.Add(new Categorie(id, naam));
                }

                return categorieen;
            }
            catch
            {
                return null;
            }
            finally
            {
                verbinding.Close();
            }
        }

        public List<Categorie> VerkrijgCategorieen(Categorie hoofdCat)
        {
            try
            {
                string sql = "SELECT BIJDRAGE_ID, NAAM FROM CATEGORIE WHERE CATEGORIE_ID = :CATID";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":CATID", hoofdCat.ID);

                OracleDataReader reader = VoerMultiQueryUit(command);

                List<Categorie> categorieen = new List<Categorie>();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["BIJDRAGE_ID"]);
                    string naam = reader["NAAM"].ToString();

                    categorieen.Add(new Categorie(id, naam));
                }

                return categorieen;
            }
            catch
            {
                return null;
            }
            finally
            {
                verbinding.Close();
            }
        }

        public Categorie VerkrijgCategorie(string naam)
        {
            try
            {
                string sql = "SELECT BIJDRAGE_ID, NAAM FROM CATEGORIE WHERE UPPER(NAAM) = :CNAAM";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":CNAAM", naam.ToUpper());

                OracleDataReader reader = VoerQueryUit(command);

                int id = Convert.ToInt32(reader["BIJDRAGE_ID"]);
                string cNaam = reader["NAAM"].ToString();

                return new Categorie(id, cNaam);
            }
            catch
            {
                return null;
            }
            finally
            {
                verbinding.Close();
            }
        }

        public List<Bestand> VerkrijgBestanden()
        {
            try
            {
                string sql = "SELECT bi.ID AS BI_ID, bi.DATUM AS BI_DATUM, b.NAAM AS B_NAAM, b.BESTANDSLOCATIE AS B_BESTANDSLOCATIE, b.GROOTTE AS B_GROOTTE, a.ID AS A_ID, a.GEBRUIKERSNAAM AS A_GEBRUIKERSNAAM FROM BIJDRAGE bi, BESTAND b, ACCOUNT a WHERE bi.ID = b.BIJDRAGE_ID AND a.ID = bi.ACCOUNT_ID ORDER BY bi.ID DESC";

                OracleCommand command = MaakOracleCommand(sql);

                OracleDataReader reader = VoerMultiQueryUit(command);

                List<Bestand> bestanden = new List<Bestand>();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["BI_ID"]);
                    DateTime datum = Convert.ToDateTime(reader["BI_DATUM"]);
                    string naam = reader["B_NAAM"].ToString();
                    string bestandLocatie = reader["B_BESTANDLOCATIE"].ToString();
                    int grootte = Convert.ToInt32(reader["B_GROOTTE"]);
                    
                    int accId = Convert.ToInt32(reader["A_ID"]);
                    string accNaam = reader["A_GEBRUIKERSNAAM"].ToString();

                    Account a = new Account(accId, accNaam);

                    bestanden.Add(new Bestand(id, datum, a, null, naam, bestandLocatie, grootte));
                }

                return bestanden;
                
            }
            catch
            {
                return null;
            }
            finally
            {
                verbinding.Close();
            }
        }

        public List<Bestand> VerkrijgBestanden(Categorie cat)
        {
            try
            {
                string sql = "SELECT bi.ID AS BI_ID, bi.DATUM AS BI_DATUM, b.NAAM AS B_NAAM, b.BESTANDSLOCATIE AS B_BESTANDSLOCATIE, b.GROOTTE AS B_GROOTTE, a.ID AS A_ID, a.GEBRUIKERSNAAM AS A_GEBRUIKERSNAAM FROM BIJDRAGE bi, BESTAND b, ACCOUNT a WHERE bi.ID = b.BIJDRAGE_ID AND a.ID = bi.ACCOUNT_ID AND b.CATEGORIE_ID = :CID ORDER BY bi.ID DESC";

                OracleCommand command = MaakOracleCommand(sql);

                command.Parameters.Add(":CID", cat.ID);

                OracleDataReader reader = VoerMultiQueryUit(command);

                List<Bestand> bestanden = new List<Bestand>();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["BI_ID"]);
                    DateTime datum = Convert.ToDateTime(reader["BI_DATUM"]);
                    string naam = reader["B_NAAM"].ToString();
                    string bestandLocatie = reader["B_BESTANDLOCATIE"].ToString();
                    int grootte = Convert.ToInt32(reader["B_GROOTTE"]);

                    int accId = Convert.ToInt32(reader["A_ID"]);
                    string accNaam = reader["A_GEBRUIKERSNAAM"].ToString();

                    Account a = new Account(accId, accNaam);

                    bestanden.Add(new Bestand(id, datum, a, null, naam, bestandLocatie, grootte));
                }

                return bestanden;

            }
            catch
            {
                return null;
            }
            finally
            {
                verbinding.Close();
            }
        }
        #endregion

        #region Queries/PlekReservering

        public List<string> VerkrijgPlekFilters(int eventID)
        {
            try
            {
                // bepaalde specificaties zijn niet filterbaar met een check (ja/nee)
                // eigenlijk gebruiken wij dit soort specificaties niet, maar voor de zekerheid worden deze 3 id's toch gefilterd in de query.
                string sql = "SELECT NAAM FROM SPECIFICATIE WHERE ID NOT IN ( 4, 6, 7 )";

                OracleCommand command = MaakOracleCommand(sql);

                OracleDataReader reader = VoerMultiQueryUit(command);

                List<string> filters = new List<string>();
                
                while (reader.Read())
                {
                    filters.Add(reader["NAAM"].ToString());
                }

                return filters;
            }
            catch
            {
                return null;
            }
            finally
            {
                verbinding.Close();
            }
        }

        #endregion

        #endregion
    }
}