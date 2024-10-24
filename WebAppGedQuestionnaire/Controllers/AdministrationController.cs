using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppGedQuestionnaire.Controllers
{
    public class AdministrationController : Controller
    {

        public AdministrationController()
        {

        }



        public IActionResult Index()
        {
            return View();
        }



    }
}
