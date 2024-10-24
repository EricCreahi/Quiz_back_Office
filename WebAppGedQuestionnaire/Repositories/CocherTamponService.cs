using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppGedQuestionnaire.Interfaces;
using WebAppGedQuestionnaire.Models;
using WebAppGedQuestionnaire.Persistences;

namespace WebAppGedQuestionnaire.Repositories
{
    public class CocherTamponService : ICocherTampon
    {
        private readonly Db_Ged_Questionnaire_Context db;

        public CocherTamponService(Db_Ged_Questionnaire_Context db)
        {
            this.db = db;
        }


        public void ajouterCocherTampon(CocherTampon cocherTampon)
        {
            if(cocherTampon != null)
            {
                
                db.CocherTampons.Add(cocherTampon);
                db.SaveChanges();               
            }
        }

        public void deleteCocherTampon(int Id)
        {
            if(Id >= 0){

                CocherTampon cocherTampon = db.CocherTampons.Find(Id);
                db.CocherTampons.Remove(cocherTampon);
                db.SaveChanges();
              
            }
        }

        public async Task<IEnumerable<CocherTampon>> ListeCocherTampon(string matricule)
        {

            var nbre = string.Format("{0:000000}", double.Parse(matricule));
            return await db.CocherTampons

                    .Where(p=>p.Matricule == nbre)
                    .Select(o => new CocherTampon()
                    {
                        CocherTamponId = o.CocherTamponId,
                        Date_Cocher = o.Date_Cocher,
                        Matricule = o.Matricule,
                        ChoixId = o.ChoixId,
                        Page = o.Page,
                        Position = o.Position,
                        Suivant = o.Suivant,
                        SousQuestionId = o.SousQuestionId,
                        NbreChoixRestant = o.NbreChoixRestant,
                        QuestionId = o.QuestionId,
                        Precedent = o.Precedent
                    })
                    .OrderByDescending(u=>u.CocherTamponId)
                    .ToListAsync();

        }

        public async Task<IEnumerable<CocherTampon>> ListeCocherTampon(string matricule, int page)
        {
            var nbre = string.Format("{0:000000}", double.Parse(matricule));
            return await db.CocherTampons

                    .Where(p => p.Matricule == nbre && p.Page == page)
                    .Select(o => new CocherTampon()
                    {
                        CocherTamponId = o.CocherTamponId,
                        Date_Cocher = o.Date_Cocher,
                        Matricule = o.Matricule,
                        ChoixId = o.ChoixId,
                        Page = o.Page,
                        Position = o.Position,
                        Suivant = o.Suivant,
                        SousQuestionId = o.SousQuestionId,
                        QuestionId = o.QuestionId,
                        NbreChoixRestant = o.NbreChoixRestant,
                        Precedent = o.Precedent
                    })                    
                    .OrderByDescending(u => u.CocherTamponId)
                    .ToListAsync();
        }

        public IEnumerable<CocherTampon> noAsynListeCocherTampon(string matricule)
        {
            return db.CocherTampons
                     .Where(p => p.Matricule == matricule)
                     .Select(o => new CocherTampon()
                     {
                         CocherTamponId = o.CocherTamponId,
                         Date_Cocher = o.Date_Cocher,
                         Matricule = o.Matricule,
                         ChoixId = o.ChoixId,
                         Page = o.Page,
                         Position = o.Position,
                         Suivant = o.Suivant,
                         SousQuestionId = o.SousQuestionId,
                         NbreChoixRestant = o.NbreChoixRestant,
                         QuestionId = o.QuestionId,
                         Precedent = o.Precedent
                     }).ToList();
        }

        public int rechercherCocherTamponId(string matricule)
        {
            throw new NotImplementedException();
        }
    }
}
