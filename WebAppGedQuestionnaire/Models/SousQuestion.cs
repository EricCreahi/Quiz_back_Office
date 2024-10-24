using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppGedQuestionnaire.Models
{
    [Table(name: "TBL_SOUS_QUESTION", Schema = "dbo")]
    public class SousQuestion
    {
        [Key]
        public int SousQuestionId { get; set; }
        public string Libelle_Sous_Question { get; set; }
        public int Numero_Sous_Question { get; set; }
        public Boolean EstVisible { get; set; }

        public int QuestionId { get; set; }

        [ForeignKey("QuestionId")]
        public Question question { get; set; }


        public List<Choix> Choixes { get; set; }

    }
}
