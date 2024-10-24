using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppGedQuestionnaire.Models;

namespace WebAppGedQuestionnaire.Interfaces
{
   public interface ICocherTampon
    {
        public void ajouterCocherTampon(CocherTampon cocherTampon);

        public Task<IEnumerable<CocherTampon>> ListeCocherTampon(string matricule);
        public Task<IEnumerable<CocherTampon>> ListeCocherTampon(string matricule, int page);

        public IEnumerable<CocherTampon> noAsynListeCocherTampon(string matricule);
        public void deleteCocherTampon(int Id);

        public int rechercherCocherTamponId(string matricule);


    }
}
