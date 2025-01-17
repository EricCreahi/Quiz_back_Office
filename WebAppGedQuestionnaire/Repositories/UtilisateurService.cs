﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using WebAppGedQuestionnaire.Interfaces;
using WebAppGedQuestionnaire.Models;
using WebAppGedQuestionnaire.Persistences;

namespace WebAppGedQuestionnaire.Repositories
{
    public class UtilisateurService : IUtilisateur
    {
        private readonly Db_Ged_Questionnaire_Context db;
        private readonly IHttpContextAccessor context;    
        private bool premiereConnexion;
      

        public UtilisateurService(Db_Ged_Questionnaire_Context db, IHttpContextAccessor context)
        {
            this.db = db;
            this.context = context;        
        }

        public bool PremierConnexion { get => premiereConnexion; set => premiereConnexion = value; }

        public Utilisateur AddOneUtilisateur(Utilisateur utilisateur)
        {
            if (utilisateur != null && Exists(utilisateur.UserId) == false)
            {
                db.Utilisateurs.Add(utilisateur);               
            }
            else
            {
                utilisateur = null;
            }
            return utilisateur;
        }

        public Utilisateur Authentification(string login, string motDePasse)
        {
            Utilisateur _utilisateur = new Utilisateur();

            if (login.Trim() != null && motDePasse.Trim() != null)
            {                
                _utilisateur.UserId = login;
                _utilisateur.UserPassword = motDePasse;

                _utilisateur = getOneutilisateur(_utilisateur.UserId); // only for developpement purpose offline              
               // _utilisateur = IsValideUser(_utilisateur, motDePasse); // fonction qui me permet simplement de recupérer la liste des utilisateurs.

                //--- mise à jour de la table employe ---//
                if(_utilisateur != null)
                UpdateOneEmploye(_utilisateur.Usermatricule,_utilisateur.Mail);
            }

            return _utilisateur;         
        }

        private void UpdateOneEmploye(string usermatricule, string mail)
        {
            if(usermatricule != null && mail!= null)
            {
                var employe = db.Employes.FirstOrDefault(o=>o.Matricule == usermatricule);
                if(employe != null)
                {
                    employe.Mail = mail;
                    db.Employes.Update(employe);
                    db.SaveChanges();
                }
            }
        }

        public bool Exists(string UserId)
        {
            return db.Utilisateurs.Any(e => e.UserId == UserId);
        }

        public IEnumerable<Utilisateur> GetAllUtilisateur()
        {
            return db.Utilisateurs
                    .Select(p => new Utilisateur()
                    {
                        UserId = p.UserId,
                        Nom = p.Nom,
                        Prenoms = p.Prenoms,
                        Mail = p.Mail,
                        UserEstActif = p.UserEstActif,
                        DateCreation = p.DateCreation,
                        Usermatricule = p.Usermatricule,
                        UserPassword = p.UserPassword,
                        DroitAcces = p.DroitAcces,
                        Audits = p.Audits.Select(u => new Audit()
                        {
                            UserId = u.UserId,
                            DateTrace = u.DateTrace,
                            DetailAction = u.DetailAction,
                            TypeAction = u.TypeAction,
                            IpSource = u.IpSource

                        }).ToList()

                    }).ToList();
        }

        public string GetContext()
        {
         return  context.HttpContext.Connection.RemoteIpAddress.ToString();
        }

        public Utilisateur getOneutilisateur(string loginuser)
        {
            return db.Utilisateurs
                .Where(o=>o.UserId == loginuser)
                .Select(p => new Utilisateur()
                {
                    UserId = p.UserId,
                    Nom = p.Nom,
                    Prenoms = p.Prenoms,
                    Mail = p.Mail,
                    UserEstActif = p.UserEstActif,
                    DateCreation = p.DateCreation,
                    Usermatricule = p.Usermatricule,                   
                    DroitAccesId = p.DroitAccesId,
                    Audits = p.Audits.Select(u => new Audit()
                    {
                        UserId = u.UserId,
                        DateTrace = u.DateTrace,
                        DetailAction = u.DetailAction,
                        TypeAction = u.TypeAction,
                        IpSource = u.IpSource

                    }).ToList()


                }
                ).FirstOrDefault();
        }


        public Utilisateur getOneutilisateurByMatricule(string matricule)
        {
            return db.Utilisateurs
                       .Where(o => o.Usermatricule == matricule && o.UserEstActif == true)
                       .Select(p => new Utilisateur()
                       {
                           UserId = p.UserId,
                           Nom = p.Nom,
                           Prenoms = p.Prenoms,
                           Mail = p.Mail,
                           UserEstActif = p.UserEstActif,
                           DateCreation = p.DateCreation,
                           Usermatricule = p.Usermatricule,                         
                           DroitAccesId = p.DroitAccesId,
                           Audits = p.Audits.Select(u => new Audit()
                           {
                               UserId = u.UserId,
                               DateTrace = u.DateTrace,
                               DetailAction = u.DetailAction,
                               TypeAction = u.TypeAction,
                               IpSource = u.IpSource

                           }).ToList()


                       }
                       ).FirstOrDefault();

        }

        public void UpdateOneUtilisateur(string matricule, Utilisateur utilisateur)
        {
            if(matricule != null && utilisateur != null)
            {
                Utilisateur oldUser = db.Utilisateurs.Where(p => p.Usermatricule == matricule).FirstOrDefault();
                if(oldUser != null)
                {

                    oldUser.Nom = utilisateur.Nom;
                    oldUser.Prenoms = utilisateur.Prenoms;               
                    oldUser.Usermatricule = utilisateur.Usermatricule;
                    oldUser.UserEstActif = utilisateur.UserEstActif;
                    oldUser.Mail = utilisateur.Mail; 
                    oldUser.DateCreation = utilisateur.DateCreation;
                    oldUser.DroitAccesId = utilisateur.DroitAccesId;    
                    
                    db.Utilisateurs.Update(oldUser);
                }                

            }   
        }



        //fonction permettant de vérifier si l'utilisateur qui souhaite se connecter existe dans l'AD
        private Utilisateur IsValideUser(Utilisateur _utilisateur, string motDePasse)
        {
            
            try
            {
               

                string sUser = _utilisateur.UserId.Trim();
                string mdp = motDePasse.Trim();

                DirectoryEntry entry = new DirectoryEntry("LDAP://SUCAFCI", sUser, mdp);

                DirectorySearcher search = new DirectorySearcher(entry);
                search.Filter = "(sAMAccountName=" + sUser + ")";
                search.PropertiesToLoad.Add("cn");

                SearchResult result = search.FindOne();


                if (result != null)
                {
                    //-- rechercher s'il existe dans la table utilisateur 
                    var userRecherche = getOneutilisateur(sUser);
                    if (userRecherche == null)
                    {
                        //--- prendre les données dans le AD et l'ajouter à la table
                        DirectoryEntry DirEntry = result.GetDirectoryEntry();


                        //--- l'utilisateur existe dans l'AD mais pas dans table utilisateur alors est ajouté
                        if (DirEntry != null)
                        {
                            _utilisateur.UserPassword = "sucafci";
                            _utilisateur.DateCreation = System.DateTime.Now;                           
                            _utilisateur.UserEstActif = true;
                            _utilisateur.DroitAccesId = 1;


                            _utilisateur.UserId = DirEntry.Properties["sAMAccountName"].Value != null ? DirEntry.Properties["sAMAccountName"].Value.ToString() : userRecherche.UserId = null;
                            _utilisateur.Nom = DirEntry.Properties["sn"].Value != null ? DirEntry.Properties["sn"].Value.ToString() : userRecherche.Nom = null;
                            _utilisateur.Prenoms = DirEntry.Properties["givenName"].Value != null ? DirEntry.Properties["givenName"].Value.ToString() : userRecherche.Prenoms = null;
                            _utilisateur.Mail = DirEntry.Properties["mail"].Value != null ? DirEntry.Properties["mail"].Value.ToString() : userRecherche.Mail = null;
                            _utilisateur.Usermatricule = DirEntry.Properties["description"].Value != null ? DirEntry.Properties["description"].Value.ToString() : userRecherche.Usermatricule = null;

                            var newuser = AddOneUtilisateur(_utilisateur);

                            if (newuser != null)
                            {
                                #region ----- // ajouter opération audit Utilisateur ajouté //----
                                Audit Audit = new Audit();
                                Audit.UserId = _utilisateur.UserId;
                                Audit.TypeAction = "Utilisateur ajouté";
                                Audit.DetailAction = "Utilisateur présent dans l'AD et ajouté à la table utilsateur";
                                Audit.DateTrace = System.DateTime.Now;
                                Audit.IpSource = GetContext();
                                db.Audites.Add(Audit);
                                db.SaveChanges();
                                premiereConnexion = true;
                                #endregion

                                return newuser;
                            }
                            else
                            {
                                #region ----- // ajouter opération audit Echec connexion //----
                                Audit Audit = new Audit();
                                Audit.UserId = _utilisateur.UserId;
                                Audit.TypeAction = "Echec connexion";
                                Audit.DetailAction = "Utilisateur n'est pas activé dans la table utilisateur";
                                Audit.DateTrace = System.DateTime.Now;
                                Audit.IpSource = GetContext();
                                db.Audites.Add(Audit);
                                db.SaveChanges();
                                #endregion

                                return newuser;
                            }
                        }

                    }
                    else
                    {
                        return userRecherche;
                    }              



                }
                else
                {
                    #region ----- // ajouter opération audit Echec connexion //----
                    Audit Audit = new Audit();
                    Audit.UserId = _utilisateur.UserId;
                    Audit.TypeAction = "Echec connexion";
                    Audit.DetailAction = "Utilisateur non présent dans l'AD";
                    Audit.DateTrace = System.DateTime.Now;
                    Audit.IpSource = GetContext();
                    db.Audites.Add(Audit);
                    db.SaveChanges();
                    #endregion



                    return _utilisateur;
                }

                return _utilisateur;

            }
            catch (Exception ex)
            {

                //--- Vérifier si l'utilisateur existe et est actif dans la table utilisateur
                var userRecherche = getOneutilisateur(_utilisateur.UserId);

                if (userRecherche != null)
                {
                    if(userRecherche.UserEstActif != _utilisateur.UserEstActif)
                    {
                        #region ----- // ajouter opération Audit_1 Echec connexion //----
                        Audit Audit_1 = new Audit();
                        Audit_1.UserId = "admin-auto-sort-veh";
                        Audit_1.TypeAction = "Problème login :" + _utilisateur.UserId + "incorrecte";
                        Audit_1.DetailAction = ex.Message;
                        Audit_1.DateTrace = System.DateTime.Now;
                        Audit_1.IpSource = GetContext();
                        db.Audites.Add(Audit_1);
                        db.SaveChanges();
                        #endregion
                    }
                 


                }
                else
                {

                    #region ----- // ajouter opération Audit_3 Echec connexion //----
                    Audit Audit_3 = new Audit();
                    Audit_3.UserId = "admin-auto-sort-veh";
                    Audit_3.TypeAction = "Problème login :" + _utilisateur.UserId  + " l'utilisateur est désactivé ou non présent dans l'AD ou pas dans notres table uilisateur";
                    Audit_3.DetailAction = ex.Message;
                    Audit_3.DateTrace = System.DateTime.Now;
                    Audit_3.IpSource = GetContext();
                    db.Audites.Add(Audit_3);
                    db.SaveChanges();
                    #endregion

                }

                return _utilisateur;


            }              
            

        }

      
    }

  
}
