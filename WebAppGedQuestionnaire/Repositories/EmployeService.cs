using WebAppGedQuestionnaire.Interfaces;
using WebAppGedQuestionnaire.Models;
using WebAppGedQuestionnaire.Persistences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppGedQuestionnaire.Repositories
{
    public class EmployeService : IEmploye
    {
        private readonly Db_Ged_Questionnaire_Context db;

        public EmployeService(Db_Ged_Questionnaire_Context db)
        {
            this.db = db;
        }




        public bool connexion(int matricule)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employe> ListeEmploye()
        {
            throw new NotImplementedException();
        }

        public Employe unEmploye(int matricule)
        {
            var _matricule = string.Format("{0:000000}", matricule);


            Employe emp = db.Employes
                .Where(p => p.Matricule == _matricule && p.Date_Sortie == "000000")
                .Select(o => new Employe()
                {
                    NomPrenoms = o.NomPrenoms,
                    Matricule = o.Matricule,
                    Site = o.Site,
                    Direction = o.Direction,
                    Service = o.Service,
                    Fonction = o.Fonction              
                }).FirstOrDefault();

                

            return emp;

        }
    }
}
