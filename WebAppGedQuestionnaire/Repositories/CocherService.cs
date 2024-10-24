using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppGedQuestionnaire.Interfaces;
using WebAppGedQuestionnaire.Models;
using WebAppGedQuestionnaire.Persistences;

namespace WebAppGedQuestionnaire.Repositories
{
    public class CocherService : ICocher
    {
        private readonly Db_Ged_Questionnaire_Context db;

        public CocherService(Db_Ged_Questionnaire_Context db)
        {
            this.db = db;
        }

        public void ajouterCocher(Cocher cocher)
        {
            if(cocher != null)
            {
                db.Cochers.Add(cocher);
                db.SaveChanges();
            }
        }

        public IEnumerable<Cocher> ListeCoche()
        {
            return db.Cochers.ToList();
        }

        public IEnumerable<Cocher> noAsynListeCocher(string matricule)
        {
           return db.Cochers
                .Where(v=>v.Matricule == matricule)
                .Select(o => new Cocher()
                {
                    CocherId = o.CocherId,
                    Date_Cocher = o.Date_Cocher,
                    Employe = o.Employe,
                    Choix = o.Choix
                }).ToList();

        }
    }
}
