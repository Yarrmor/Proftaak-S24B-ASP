using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using Oracle.DataAccess.Client;
using System.Data;

namespace Proftaak_S24B_ASP
{
    public class DatabaseManager
    {
        public string PCN;
        public string Wachtwoord;
        //public OracleConnection Verbinding;

        public DatabaseManager()
        {
            //this.PCN = "dbi255847";
            //this.Wachtwoord = "u1eoeVfvUI";

            //Verbinding = new OracleConnection();

            //Verbinding.ConnectionString = "User Id=" + this.PCN + ";Password=" + this.Wachtwoord + ";Data Source=" + "//192.168.15.50:1521/fhictora;";
        }

        public string Test()
        {
            //OracleCommand cmd = new OracleCommand("SELECT RFID FROM ACCOUNT WHERE AccountID = 1", this.Verbinding);
            //cmd.CommandType = System.Data.CommandType.Text;

            //try
            //{
            //    if (Verbinding.State == ConnectionState.Closed)
            //    {
            //        Verbinding.Open();
            //    }

            //    OracleDataReader reader = cmd.ExecuteReader();

            //    reader.Read();

            //    return reader["RFID"].ToString();
            //}
            //catch
            //{
            //    return null;
            //}
            //finally
            //{
            //    Verbinding.Close();
            //}
            return "";
        }

    }
}