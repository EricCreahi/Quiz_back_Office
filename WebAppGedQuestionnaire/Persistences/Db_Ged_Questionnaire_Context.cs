using WebAppGedQuestionnaire.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppGedQuestionnaire.Persistences
{
    public class Db_Ged_Questionnaire_Context : DbContext
    {

        public DbSet<Choix> Choixes { get; set; }
        public DbSet<Cocher> Cochers { get; set; }
        public DbSet<Employe> Employes { get; set; }
        public DbSet<Realiser> Realisers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Questionnaire> Questionnaires { get; set; }
        public DbSet<CocherTampon> CocherTampons { get; set; }

        public DbSet<Audit> Audites { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<DroitAcces> DroitAcces { get; set; }

        public DbSet<SousQuestion> SousQuestions { get; set; }

        public Db_Ged_Questionnaire_Context(DbContextOptions<Db_Ged_Questionnaire_Context> options): base(options){ }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
