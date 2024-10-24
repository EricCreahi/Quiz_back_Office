using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppGedQuestionnaire.Models
{

    [Table(name: "TBL_COCHER", Schema = "dbo")]
    public class Cocher
    {
        [Key]
        public int CocherId { get; set; }
        public DateTime Date_Cocher { get; set; }
        public string Matricule { get; set; }
        [ForeignKey("Matricule")]
        public  Employe Employe { get; set; }

        public int ChoixId { get; set; }
        [ForeignKey("ChoixId")]
        public Choix Choix { get; set; }

    }


}
