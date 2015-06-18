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

        #endregion
    }
}