using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppGedQuestionnaire.Controllers.Dto.Resources
{
    public class ChoixResDto
    {     
        public int ChoixId { get; set; }
        public string Libelle_Choix { get; set; }
        public Boolean EstVisible { get; set; }
        public int QuestionId { get; set; }     
        
    }
}
