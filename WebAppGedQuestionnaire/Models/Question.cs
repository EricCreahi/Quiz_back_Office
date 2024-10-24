using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppGedQuestionnaire.Models
{

    [Table(name: "TBL_QUESTION", Schema = "dbo")]
    public class Question
    {

        [Key]
        public int QuestionId { get; set; }
        public string Libelle_Question { get; set; }
        public int Numero_Question { get; set; }
        public Boolean EstVisible { get; set; }

        public int QuestionnaireId { get; set; }
         [ForeignKey("QuestionnaireId")]
        public Questionnaire Questionnaire { get; set; }

        public List<SousQuestion> SousQuestions { get; set; }
    }
}
