using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppGedQuestionnaire.Controllers.Dto.Requetes
{
    public class PageRqDto
    {
        public int Id { get; set; }
        public int page { get; set; }

        public int nbreChoix { get; set; }
    }
}
