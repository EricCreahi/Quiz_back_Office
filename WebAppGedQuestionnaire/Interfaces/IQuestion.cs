using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppGedQuestionnaire.Models;

namespace WebAppGedQuestionnaire.Interfaces
{
    public interface IQuestion
    {
        public void ajouterQuestion(int pkQuestionnaire);
        public void modifierQuestion(int Id);
        public Task<IEnumerable<Question>> ListeQuestion();

        public IEnumerable<Question> noAsynListeQuestion();

        public Task<IEnumerable<Question>> ListeReponseQuestion( int id);

        public Question ReponseQuestion(int id);
        public Question ChoixQuestion(int id);


    }
}
