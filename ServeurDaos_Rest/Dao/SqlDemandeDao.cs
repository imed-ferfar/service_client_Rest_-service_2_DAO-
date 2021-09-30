using MySqlConnector;
using NPOI.SS.Util;
using ServeurDaos_Rest.Models;
using ServeurDaos_Rest.Singleton;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace ServeurDaos_Rest.Dao
{
    public class SqlDemandeDao : DemandeDao
    {
        public void AddRequest(Demande dem)
        {
            MySqlCommand sqlCmd;
            DbDataReader dr;
            string rq;
            using (MySqlConnection cnx = BddConnexion.GetConnexion())
            {
                rq = "INSERT INTO `demande` (`host`, `user`, `date`, `time`, `year`, `message`) VALUES" +
                "(@host, @user, @date, @time, @year, @message);";

                SimpleDateFormat formatter1 = new SimpleDateFormat("dd-MM-yyyy");
                SimpleDateFormat formatter2 = new SimpleDateFormat("HH:mm:ss");
                sqlCmd = cnx.CreateCommand();
                sqlCmd.CommandText = rq;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("host", dem.Host);
                sqlCmd.Parameters.AddWithValue("user", dem.User);
                sqlCmd.Parameters.AddWithValue("date", dem.TimeStamp.ToShortDateString());
                sqlCmd.Parameters.AddWithValue("time", dem.TimeStamp.ToLongTimeString());
                sqlCmd.Parameters.AddWithValue("year", dem.Year);
                sqlCmd.Parameters.AddWithValue("message", dem.Message);

                dr = sqlCmd.ExecuteReader();
                BddConnexion.Fermer();
            }
        }

        public List<Demande> GetAllRequest()
        {
            MySqlCommand sqlCmd;
            DbDataReader dr;
            string rq;
            List<Demande> list_dem = new List<Demande>();
            Demande dem;
            using (MySqlConnection cnx = BddConnexion.GetConnexion())
            {
                rq = "SELECT * FROM demande;";
                sqlCmd = cnx.CreateCommand();
                sqlCmd.CommandText = rq;
                sqlCmd.CommandType = CommandType.Text;
                dr = sqlCmd.ExecuteReader();
                while (dr.Read())
                {
                    dem = new Demande();
                    dem.Host = (string)dr["host"];
                    dem.User = dr.GetString(1);
                    dem.TimeStamp = dr.GetDateTime(3);
                    dem.Time = (string)dr["time"];
                    dem.Message = (string)dr["message"];
                    dem.Year = (int)dr["year"];

                    list_dem.Add(dem);
                }
                BddConnexion.Fermer();
            }
            return list_dem;
        }

        public List<Demande> GetDayRequest()
        {
            MySqlCommand sqlCmd;
            DbDataReader dr;
            string rq;
            List<Demande> list_dem = new List<Demande>();
            Demande dem;
            using (MySqlConnection cnx = BddConnexion.GetConnexion())
            {
                string jour = DateTime.Now.ToShortDateString();
                rq = "select * from demande where date = DATE_FORMAT(sysdate(), '%Y-%m-%d')";
                sqlCmd = cnx.CreateCommand();
                sqlCmd.CommandText = rq;
                sqlCmd.CommandType = CommandType.Text;
               // sqlCmd.Parameters.AddWithValue("date", jour);
                dr = sqlCmd.ExecuteReader();
                while (dr.Read())
                {
                    dem = new Demande();
                    dem.Host = (string)dr["host"];
                    dem.User = dr.GetString(1);
                    dem.TimeStamp = dr.GetDateTime(3);
                    dem.Time = (string)dr["time"];
                    dem.Message = (string)dr["message"];
                    dem.Year = (int)dr["year"];

                    list_dem.Add(dem);
                }
                BddConnexion.Fermer();
            }
            return list_dem;
        }
    }
}
