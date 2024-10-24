using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppGedQuestionnaire.Models
{

    [Table(name: "TBL_QUESTIONNAIRE", Schema = "dbo")]
    public class Questionnaire
    {
        [Key]
        public int QuestionnaireId { get; set; }
        public string Titre { get; set; }
        public DateTime Date_debut { get; set; }
        public DateTime  Date_Fin { get; set; }
        public Boolean EstActif { get; set; }

        public List<Realiser> Realisers { get; set; }
        public List<Question> Questions { get; set; }


    }
}
