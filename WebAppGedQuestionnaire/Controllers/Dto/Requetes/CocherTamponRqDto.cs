using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppGedQuestionnaire.Controllers.Dto.Requetes
{
    public class CocherTamponRqDto
    {      
        public int CocherTamponId { get; set; }
        public DateTime Date_Cocher { get; set; }       
        public string Matricule { get; set; }
        public int ChoixId { get; set; }
        public int Page { get; set; }
        public int Position { get; set; }
        public int SousQuestionId { get; set; }
        public int QuestionId { get; set; }
        public int NbreChoixRestant { get; set; }
        public Boolean Suivant { get; set; }
        public Boolean Precedent { get; set; }



    }
}
