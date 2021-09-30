using ServeurDaos_Rest.Models;
using ServeurDaos_Rest.Service;
using ServeurDaos_Rest.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Windows.Forms;

namespace ServeurDaos_Rest.Controllers
{
    public class DemandeController : ApiController
    {
        // GET: api/Demande
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Demande/5
        public List<Demande> Get(string motCle)
        {
            //http://localhost:62954/api/Demande?id=5
             /*  MessageBox.Show("Test ser:" + motCle,
                      "Echéc de connexion!", MessageBoxButtons.OK, MessageBoxIcon.Error);*/
            BddConnexion.SetUrlBD("Server = 127.0.0.1;");
            BddConnexion.SetUser("Uid=root;");
            BddConnexion.SetPassword("Pwd=root;");
            BddConnexion.SetBdd("Database=a15;");

            return DemandeServices.GetDemandes(motCle);
        }

        // POST: api/Demande
        public void Post([FromBody] Demande demande)
        {
            BddConnexion.SetUrlBD("Server = 127.0.0.1;");
            BddConnexion.SetUser("Uid=root;");
            BddConnexion.SetPassword("Pwd=root;");
            BddConnexion.SetBdd("Database=a15;");

            DemandeServices.AjouterDemande(demande);
        }

        // PUT: api/Demande/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Demande/5
        public void Delete(int id)
        {
        }
    }
}
