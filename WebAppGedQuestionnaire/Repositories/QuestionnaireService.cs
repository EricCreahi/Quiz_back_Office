using WebAppGedQuestionnaire.Interfaces;
using WebAppGedQuestionnaire.Models;
using WebAppGedQuestionnaire.Persistences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppGedQuestionnaire.Repositories
{
    public class QuestionnaireService : IQuestionnaire
    {
        private readonly Db_Ged_Questionnaire_Context db;

        public QuestionnaireService(Db_Ged_Questionnaire_Context db)
        {
            this.db = db;
        }



        public void ajouterQuestion()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Questionnaire> ListeQuestionnnaire()
        {
            throw new NotImplementedException();
        }

        public void supprimerQuestion(int id)
        {
            throw new NotImplementedException();
        }
    }
}
