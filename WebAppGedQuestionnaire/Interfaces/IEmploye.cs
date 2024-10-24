using WebAppGedQuestionnaire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppGedQuestionnaire.Interfaces
{
   public interface IEmploye
   {
        public bool connexion(int matricule);
        public Employe unEmploye(int matricule);
        public IEnumerable<Employe> ListeEmploye();

    
   }
}
