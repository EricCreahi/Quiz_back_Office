using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppGedQuestionnaire.Models
{

    [Table(name: "TBL_REALISER", Schema = "dbo")]
    public class Realiser
    {
        [Key]
        public int RealiserId { get; set; }

        public DateTime Date_Realiser { get; set; }

        [Column(Order = 0), StringLength(20)]
        public string Matricule { get; set; }
        [ForeignKey("Matricule")]
        public Employe Employe { get; set; }




        public int QuestionnaireId { get; set; }

        [ForeignKey("QuestionnaireId")]
        public Questionnaire Questionnaire { get; set; }


    }
}
