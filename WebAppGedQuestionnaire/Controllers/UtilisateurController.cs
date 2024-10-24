using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppGedQuestionnaire.Controllers.Dto.Requetes;
using WebAppGedQuestionnaire.Helpers;
using WebAppGedQuestionnaire.Interfaces;
using WebAppGedQuestionnaire.Models;

namespace WebAppGedQuestionnaire.Controllers
{
    public class UtilisateurController : Controller
    {
        private readonly IUtilisateur repo;
        private readonly IMapper mapper;

        public UtilisateurController(IUtilisateur repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }



        [HttpPost]
        public IActionResult ConnexionUser(UtilisateurReqDto user)
        {
            var emp = new Utilisateur();
            var reponse = new Reponse<Utilisateur>();

            if (user.UserId != null && user.UserPassword != null)
            {
                emp = repo.Authentification(user.UserId.Trim(), user.UserPassword.Trim());              
            }                     

            reponse.OneData = emp;       

            return Ok(reponse);
        }

        [HttpGet]
        public IActionResult InfosUser(string matricule)
        {
            var utilisateur = repo.getOneutilisateurByMatricule(matricule);
            var response = new Reponse<Utilisateur>()
            {
                OneData = utilisateur != null ? utilisateur : null
            };
            return Ok(response);
        }


    }
}
