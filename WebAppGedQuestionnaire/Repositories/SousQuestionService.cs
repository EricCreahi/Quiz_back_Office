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
    public class SousQuestionService : ISousQuestion
    {
        private readonly Db_Ged_Questionnaire_Context db;

        public SousQuestionService(Db_Ged_Questionnaire_Context db)
        {
            this.db = db;
        }



        public void ajouterSousQuestion(int pkQuestionnaire)
        {
            throw new NotImplementedException();
        }

        public SousQuestion ChoixSousQuestion(int numero,int questionid)
        {
            return db.SousQuestions
                .Where(v => v.QuestionId == questionid && v.Numero_Sous_Question == numero)
                .Select(o => new SousQuestion()
                {
                    SousQuestionId = o.SousQuestionId,
                    Libelle_Sous_Question = o.Libelle_Sous_Question,
                    Numero_Sous_Question = o.Numero_Sous_Question,
                    EstVisible = o.EstVisible,
                    question = o.question,
                    Choixes = o.Choixes.Select(p => new Choix()
                    {
                        ChoixId = p.ChoixId,
                        Libelle_Choix = p.Libelle_Choix,
                        EstVisible = p.EstVisible,
                        SousQuestion = p.SousQuestion

                    }).ToList()

                }).FirstOrDefault();
        }

        public async Task<IEnumerable<SousQuestion>> ListeReponseSousQuestion(int id)
        {
            return await db.SousQuestions
                .Where(v=>v.QuestionId == id)
                .Select(o => new SousQuestion(){
                    SousQuestionId = o.SousQuestionId,
                    Libelle_Sous_Question = o.Libelle_Sous_Question,
                    Numero_Sous_Question = o.Numero_Sous_Question,
                    EstVisible = o.EstVisible,
                    question = o.question,
                    Choixes = o.Choixes.Select(p => new Choix()
                    {
                        ChoixId = p.ChoixId,
                        Libelle_Choix = p.Libelle_Choix,
                        EstVisible = p.EstVisible,
                        SousQuestion = p.SousQuestion                   

                    }).ToList()

                }).ToListAsync();
        }

        public async Task<IEnumerable<SousQuestion>> ListeSousQuestion()
        {
          
            return await db.SousQuestions.Select(o => new SousQuestion() {
                SousQuestionId = o.SousQuestionId,
                Libelle_Sous_Question = o.Libelle_Sous_Question,
                Numero_Sous_Question = o.Numero_Sous_Question,
                EstVisible = o.EstVisible,
                question = o.question,
                Choixes = o.Choixes.Select(p => new Choix()
                {
                    ChoixId = p.ChoixId,
                    Libelle_Choix = p.Libelle_Choix,
                    EstVisible = p.EstVisible,
                    SousQuestion = p.SousQuestion

                }).ToList()
            }).ToListAsync();
        }

        public void modifierSousQuestion(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SousQuestion> noAsynListeSousQuestion()
        {
            return  db.SousQuestions.Select(o => new SousQuestion()
            {
                SousQuestionId = o.SousQuestionId,
                Libelle_Sous_Question = o.Libelle_Sous_Question,
                Numero_Sous_Question = o.Numero_Sous_Question,
                EstVisible = o.EstVisible,
                question = o.question,
                Choixes = o.Choixes.Select(p => new Choix()
                {
                    ChoixId = p.ChoixId,
                    Libelle_Choix = p.Libelle_Choix,
                    EstVisible = p.EstVisible,
                    SousQuestion = p.SousQuestion
                }).ToList()
            }).ToList();
        }

        public SousQuestion ReponseSousQuestion(int numero, int questionId)
        {
            return db.SousQuestions
                .Where(v=>v.Numero_Sous_Question == numero && v.QuestionId == questionId)
                .Select(o => new SousQuestion() {
                SousQuestionId = o.SousQuestionId,
                Libelle_Sous_Question = o.Libelle_Sous_Question,
                Numero_Sous_Question = o.Numero_Sous_Question,
                EstVisible = o.EstVisible,
                question = o.question,
                Choixes = o.Choixes.Select(p => new Choix()
                {
                    ChoixId = p.ChoixId,
                    Libelle_Choix = p.Libelle_Choix,
                    EstVisible = p.EstVisible,
                    SousQuestion = p.SousQuestion

                }).ToList()

            }).FirstOrDefault();
        }
    }
}
