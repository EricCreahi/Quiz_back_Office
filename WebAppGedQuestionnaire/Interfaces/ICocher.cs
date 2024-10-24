using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppGedQuestionnaire.Models;

namespace WebAppGedQuestionnaire.Interfaces
{
    public interface ICocher
    {
        public void ajouterCocher(Cocher cocher);

        public IEnumerable<Cocher> ListeCoche();

        public IEnumerable<Cocher> noAsynListeCocher(string matricule);

    }
}
