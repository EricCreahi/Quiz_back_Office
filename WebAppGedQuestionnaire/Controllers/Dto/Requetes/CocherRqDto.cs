using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppGedQuestionnaire.Controllers.Dto.Requetes
{
    public class CocherRqDto
    {      
       
        public DateTime date_Cocher { get; set; }
        public string matricule { get; set; }          
        public int choixId { get; set; }     
    }
}
