using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
//using Oracle.DataAccess.Client;

namespace Proftaak_S24B_ASP
{
    public class DatabaseManager
    {
        //public string PCN;
        //public string Wachtwoord;
        //public OracleConnection Verbinding;

        //public DatabaseManager()
        //{
        //    this.PCN = "dbi255847";
        //    this.Wachtwoord = "u1eoeVfvUI";

        //    Verbinding = new OracleConnection();

        //    Verbinding.ConnectionString = "User Id=" + this.PCN + ";Password=" + this.Wachtwoord + ";Data Source=" + "//192.168.15.50:1521/fhictora;";
        //}

        ///// <summary>
        ///// Retourneert een instantie van OracleCommand met
        ///// this.Verbinding & .CommandType.Text
        ///// </summary>
        ///// <param name="sql"></param>
        ///// <returns></returns>
        //public OracleCommand MaakOracleCommand(string sql)
        //{
        //    OracleCommand command = new OracleCommand(sql, this.Verbinding);
        //    command.CommandType = System.Data.CommandType.Text;

        //    return command;
        //}

        ///// <summary>
        ///// Voert de query uit van meegegeven OracleCommand.
        ///// Deze OracleCommand moet gemaakt zijn door MaakOracleCommand() en parameters moeten al ingesteld zijn.
        ///// De teruggegeven lijst bevat voor elke rij een OracleDataReader.
        ///// </summary>
        ///// <param name="command"></param>
        ///// <returns></returns>
        //public OracleDataReader VoerMultiQueryUit(OracleCommand command)
        //{
        //    try
        //    {
        //        Verbinding.Open();

        //        OracleDataReader reader = command.ExecuteReader();

        //        return reader;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}

        ///// <summary>
        ///// Voert de query uit van meegegeven OracleCommand.
        ///// Deze OracleCommand moet gemaakt zijn door MaakOracleCommand() en parameters moeten al ingesteld zijn.
        ///// </summary>
        ///// <param name="command"></param>
        ///// <returns></returns>
        //public OracleDataReader VoerQueryUit(OracleCommand command)
        //{
        //    try
        //    {
        //        if (Verbinding.State == ConnectionState.Closed)
        //        {
        //            Verbinding.Open();
        //        }

        //        OracleDataReader reader = command.ExecuteReader();

        //        reader.Read();

        //        return reader;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}

        //public bool VoerNonQueryUit(OracleCommand command)
        //{
        //    try
        //    {
        //        Verbinding.Open();
        //        command.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        ////#---------#
        ////I QUERIES I
        ////#---------#

        //#region Account

        ///// <summary>
        ///// Returns if the given username and password are registered.
        ///// </summary>
        ///// <param name="username"></param>
        ///// <param name="password"></param>
        ///// <returns></returns>
        //public bool LogIn(string username, string password)
        //{
        //    return false;
        //}

        ///// <summary>
        ///// Returns an Account based on a given username.
        ///// </summary>
        ///// <param name="username"></param>
        ///// <returns></returns>
        //public Account GetAccount(string username)
        //{
        //    return null;
        //}

        ///// <summary>
        ///// Returns an Account based on a given account ID.
        ///// </summary>
        ///// <param name="accountID"></param>
        ///// <returns></returns>
        //public Account GetAccount(int accountID)
        //{
        //    return null;
        //}

        //#endregion
    }
}