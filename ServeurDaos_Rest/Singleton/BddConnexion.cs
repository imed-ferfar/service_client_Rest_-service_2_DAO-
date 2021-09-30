using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ServeurDaos_Rest.Singleton
{
    class BddConnexion
    {
        private static MySqlConnection laConnexion = null;

        private DbDataAdapter dataAdapter = null;
        private DbConnection cnx = null;
        private MySqlCommand sqlCmd = null;
        private DbCommand cmd = null;
        private DataTable tableBd = null;

        private static String urlBd = ""; //Server=127.0.0.1;Uid=root;Pwd=root;Database=
        private static String user = "";
        private static String motPasse = "";
        private static String bdd = "";

        //constructeur # 
        private BddConnexion()
        {
            /*cnx = new MySqlConnection();
            cnx.ConnectionString = urlBd + bdd + ";";
            cnx.Open();*/
        }


        public static void SetBdd(string bdd)
        {
            BddConnexion.bdd = bdd;
        }
        public static void SetUrlBD(string urlBd)
        {
            BddConnexion.urlBd = urlBd;
        }

        public static void SetUser(string user)
        {
            BddConnexion.user = user;
        }

        public static void SetPassword(string motPasse)
        {
            BddConnexion.motPasse = motPasse;
        }

        public static MySqlConnection GetConnexion()
        {
            try
            {
                if (laConnexion == null || laConnexion.State != ConnectionState.Open)
                {
                    if ((user.Equals("")) || (motPasse.Equals("")) || (bdd.Equals("")))
                        Console.WriteLine("Erreur des parametres de connextion");
                    else
                        laConnexion = new MySqlConnection();
                    laConnexion.ConnectionString = urlBd + user + motPasse + bdd;
                    laConnexion.Open();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Erreur : " + ex.Message);
            }
            return laConnexion;
        }

        //fermer la connexion
        public static void Fermer()
        {
            if (laConnexion != null)
                try
                {
                    laConnexion.Close();
                    laConnexion = null;
                }
                catch (SqlException ex)
                {
                    //Logger.getLogger(DbConnexion.class.getName()).log(Level.SEVERE, null, ex);
                    Console.WriteLine("Probleme : " + ex.Message);
                }
        }
    }
}