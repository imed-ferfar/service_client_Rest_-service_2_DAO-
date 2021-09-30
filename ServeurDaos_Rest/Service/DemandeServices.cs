using ServeurDaos_Rest.Dao;
using ServeurDaos_Rest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServeurDaos_Rest.Service
{
    public class DemandeServices
    {
        public static void AjouterDemande(Demande dem)
        {
            DemandeDao dao = new SqlDemandeDao();
            dao.AddRequest(dem);
        }

        public static List<Demande> GetDemandes(String motCle)
        {
            DemandeDao dao = new SqlDemandeDao();
            if (motCle.Equals("jour"))
                return dao.GetDayRequest();
            return dao.GetAllRequest();
        }
        /*
        public static List<Demande> GetDemandesDuJours()
        {
            DemandeDao dao = new SqlDemandeDao();
            return dao.GetDayRequest();
        }*/
    }
}