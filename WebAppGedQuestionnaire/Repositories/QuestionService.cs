using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppGedQuestionnaire.Interfaces;
using WebAppGedQuestionnaire.Models;
using WebAppGedQuestionnaire.Persistences;
using Microsoft.EntityFrameworkCore;

namespace WebAppGedQuestionnaire.Repositories
{
    public class QuestionService : IQuestion
    {
        private readonly Db_Ged_Questionnaire_Context db;

        public QuestionService(Db_Ged_Questionnaire_Context db )
        {
            this.db = db;
        }

        public void ajouterQuestion(int pkQuestionnaire)
        {
            throw new NotImplementedException();
        }

        public Question ChoixQuestion(int id)
        {
            return db.Questions
                .Where(v => v.Numero_Question == id)
                .Select(o => new Question()
                {
                    QuestionId = o.QuestionId,
                    Libelle_Question = o.Libelle_Question,
                    Numero_Question = o.Numero_Question,
                    SousQuestions = o.SousQuestions.Select(p => new SousQuestion()
                    {
                       SousQuestionId = p.SousQuestionId,
                       Libelle_Sous_Question = p.Libelle_Sous_Question,
                       Numero_Sous_Question = p.Numero_Sous_Question,
                       EstVisible =p.EstVisible,
                       question = p.question

                    }).ToList()

                }).FirstOrDefault();
        }

        public async Task<IEnumerable<Question>> ListeQuestion()
        {
            return await db.Questions.Select(o => new Question()
            {
                QuestionId = o.QuestionId,
                Libelle_Question = o.Libelle_Question,
                Numero_Question = o.Numero_Question,
                Questionnaire = o.Questionnaire,
                SousQuestions = o.SousQuestions.Select(p=>  new SousQuestion()
                {
                    SousQuestionId = p.SousQuestionId,
                    Libelle_Sous_Question = p.Libelle_Sous_Question,
                    Numero_Sous_Question = p.Numero_Sous_Question,
                    EstVisible = p.EstVisible,
                    question = p.question

                }).ToList()

            }).ToListAsync();
        }

        public async Task<IEnumerable<Question>> ListeReponseQuestion(int id)
        {
            return await db.Questions
                .Where(v=>v.QuestionId == id)
                .Select(o => new Question()
                {
                    QuestionId = o.QuestionId,
                    Libelle_Question = o.Libelle_Question,
                    Numero_Question = o.Numero_Question,
                    SousQuestions = o.SousQuestions.Select(p => new SousQuestion()
                    {
                        SousQuestionId = p.SousQuestionId,
                        Libelle_Sous_Question = p.Libelle_Sous_Question,
                        Numero_Sous_Question = p.Numero_Sous_Question,
                        EstVisible = p.EstVisible,
                        question = p.question

                    }).ToList()

                }).ToListAsync();

        }

        public void modifierQuestion(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Question> noAsynListeQuestion()
        {
            return  db.Questions.Select(o => new Question()
            {
                QuestionId = o.QuestionId,
                Libelle_Question = o.Libelle_Question,
                Numero_Question = o.Numero_Question,
                Questionnaire = o.Questionnaire,
                SousQuestions = o.SousQuestions.Select(p => new SousQuestion()
                {
                    SousQuestionId = p.SousQuestionId,
                    Libelle_Sous_Question = p.Libelle_Sous_Question,
                    Numero_Sous_Question = p.Numero_Sous_Question,
                    EstVisible = p.EstVisible,
                    question = p.question

                }).ToList()

            }).ToList();
        }

        public Question ReponseQuestion(int id)
        {
            return  db.Questions
                 .Where(v => v.QuestionId == id)
                 .Select(o => new Question()
                 {
                     QuestionId = o.QuestionId,
                     Libelle_Question = o.Libelle_Question,
                     Numero_Question = o.Numero_Question,
                     SousQuestions = o.SousQuestions.Select(p => new SousQuestion()
                     {
                         SousQuestionId = p.SousQuestionId,
                         Libelle_Sous_Question = p.Libelle_Sous_Question,
                         Numero_Sous_Question = p.Numero_Sous_Question,
                         EstVisible = p.EstVisible,
                         question = p.question

                     }).ToList()

                 }).FirstOrDefault();
        }
    }
}
