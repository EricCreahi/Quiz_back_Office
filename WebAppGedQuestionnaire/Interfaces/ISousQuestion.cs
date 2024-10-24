using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppGedQuestionnaire.Models;

namespace WebAppGedQuestionnaire.Interfaces
{
   public interface ISousQuestion
    {
        public void ajouterSousQuestion(int pkQuestionnaire);
        public void modifierSousQuestion(int Id);
        public Task<IEnumerable<SousQuestion>> ListeSousQuestion();

        public IEnumerable<SousQuestion> noAsynListeSousQuestion();

        public Task<IEnumerable<SousQuestion>> ListeReponseSousQuestion(int id);

        public SousQuestion ReponseSousQuestion(int numero, int questionId);
        public SousQuestion ChoixSousQuestion(int numero, int questionid);

    }
}
