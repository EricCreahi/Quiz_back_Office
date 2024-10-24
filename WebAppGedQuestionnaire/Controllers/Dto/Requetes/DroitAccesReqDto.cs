using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppGedQuestionnaire.Controllers.Dto.Requetes
{
    public class DroitAccesReqDto
    {
        public int DroitAccesId { get; set; }
        public string Libelle { get; set; }
        public int Level { get; set; }
    }
}
