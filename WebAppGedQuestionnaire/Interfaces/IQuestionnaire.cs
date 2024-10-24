using WebAppGedQuestionnaire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppGedQuestionnaire.Interfaces
{
    public   interface IQuestionnaire
    {
        public void ajouterQuestion();
        public void supprimerQuestion(int id);
        public IEnumerable<Questionnaire> ListeQuestionnnaire();


    }
}
