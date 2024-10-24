using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppGedQuestionnaire.Models;

namespace WebAppGedQuestionnaire.Interfaces
{
    public   interface IUtilisateur
    {
        public bool PremierConnexion { get; set; }
        IEnumerable<Utilisateur> GetAllUtilisateur();

        Utilisateur AddOneUtilisateur(Utilisateur utilisateur);
        Utilisateur getOneutilisateur(string loginuser);
        Utilisateur getOneutilisateurByMatricule(string matricule);
        void UpdateOneUtilisateur(string matricule, Utilisateur utilisateur);

        Utilisateur Authentification(string login, string motDePasse);
        bool Exists(string UserId);

    }
}
