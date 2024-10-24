using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppGedQuestionnaire.Models
{

    [Table(name: "TBL_CHOIX", Schema = "dbo")]
    public class Choix
    {
        [Key]
        public int ChoixId { get; set; }
        public string  Libelle_Choix { get; set; }
        public Boolean EstVisible { get; set; }

        public int SousQuestionId { get; set; }
        [ForeignKey("SousQuestionId")]
        public SousQuestion SousQuestion { get; set; }

        public int Note { get; set; }
        
    }


}
