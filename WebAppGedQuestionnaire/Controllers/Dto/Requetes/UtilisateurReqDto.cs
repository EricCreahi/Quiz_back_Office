using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppGedQuestionnaire.Controllers.Dto.Requetes
{
    public class UtilisateurReqDto
    {
        public string UserId { get; set; }
        public string Nom { get; set; }
        public string Prenoms { get; set; }
        public string Mail { get; set; }
        public bool UserEstActif { get; set; }
        public DateTime DateCreation { get; set; }
        public string UserPassword { get; set; }
        public bool ConnexionStatut { get; set; }
        public string Usermatricule { get; set; }
        public string MessageError { get; set; }
        public int DroitAccesId { get; set; }
        public string Libelle { get; set; }
        public int Level { get; set; }

        public DroitAccesReqDto DroitAcces { get; set; }
    }
}
