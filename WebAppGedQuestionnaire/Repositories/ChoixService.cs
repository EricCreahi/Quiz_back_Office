using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppGedQuestionnaire.Interfaces;
using WebAppGedQuestionnaire.Models;
using WebAppGedQuestionnaire.Persistences;
using Microsoft.EntityFrameworkCore;

namespace WebAppGedQuestionnaire.Repositories
{
    public class ChoixService : IChoix
    {
        private readonly Db_Ged_Questionnaire_Context db;

        public ChoixService(Db_Ged_Questionnaire_Context db)
        {
            this.db = db;
        }

        public Choix choix_question(int id)
        {
            return db.Choixes
                .Where(v=>v.SousQuestionId == id)
                .Select(o => new Choix()
            {
                ChoixId = o.ChoixId,
                EstVisible = o.EstVisible,
                Libelle_Choix = o.Libelle_Choix,
                SousQuestion = o.SousQuestion
                }).FirstOrDefault();
        }

        public async Task<IEnumerable<Choix>> ListeQuestionChoix()
        {
            return await db.Choixes.Select(o => new Choix()
            {

                ChoixId = o.ChoixId,
                Libelle_Choix = o.Libelle_Choix,
                EstVisible =  o.EstVisible,
                SousQuestion = o.SousQuestion != null ? o.SousQuestion : null               


            }).ToListAsync();
        }
    }
}
