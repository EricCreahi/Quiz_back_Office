using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppGedQuestionnaire.Models
{
    [Table(name: "TBL_COCHER_TAMPON", Schema = "dbo")]
    public class CocherTampon
    {
        [Key]
        [Column(Order =0)]
        public int CocherTamponId { get; set; }
        [Column(Order = 1)]
        public DateTime Date_Cocher { get; set; }
        [Column(Order = 2),StringLength(20)]
        public string Matricule { get; set; }
        [Column(Order = 3)]
        public int ChoixId { get; set; }
        [Column(Order = 4)]
        public int Page { get; set; }
        [Column(Order = 5)]
        public int Position { get; set; }

        [Column(Order = 6)]
        public int QuestionId { get; set; }

        [Column(Order = 7)]
        public int SousQuestionId { get; set; }        

        [Column(Order = 8)]
        public int NbreChoixRestant { get; set; }

        [Column(Order = 9)]
        public Boolean Suivant { get; set; }
        [Column(Order = 10)]
        public Boolean Precedent { get; set; }

   


    }
}
