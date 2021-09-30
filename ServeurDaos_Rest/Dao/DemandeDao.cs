using ServeurDaos_Rest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServeurDaos_Rest.Dao
{
    public interface DemandeDao
    {
        void AddRequest(Demande dem);

        List<Demande> GetAllRequest();

        List<Demande> GetDayRequest();
    }
}
