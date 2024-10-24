using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppGedQuestionnaire.Models;

namespace WebAppGedQuestionnaire.Interfaces
{
    public  interface IChoix
    {
        public Task<IEnumerable<Choix>> ListeQuestionChoix();
        public Choix choix_question(int id);

    }
}
