using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppGedQuestionnaire.Controllers.Dto.Resources
{
    public class QuestionResDto
    {
    
        public int QuestionId { get; set; }
        public string Libelle_Question { get; set; }
        public int Numero_Question { get; set; }
        public Boolean EstVisible { get; set; }

        public int QuestionnaireId { get; set; }    
       
        public List<ChoixResDto> Choixes { get; set; }
    }
}
