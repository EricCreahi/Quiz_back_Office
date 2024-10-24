using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppGedQuestionnaire.Controllers.Dto.Requetes;
using WebAppGedQuestionnaire.Helpers;
using WebAppGedQuestionnaire.Interfaces;
using WebAppGedQuestionnaire.Models;

namespace WebAppGedQuestionnaire.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmploye repo;
        private readonly IChoix repoChoix;
        private readonly IQuestion repoQuestion;
        private readonly ISousQuestion repoSousQuestion;
        private readonly ICocherTampon repoCocherTampon;
        private readonly IMapper mapper;
        private readonly ICocher repoCocher;

        public HomeController(ILogger<HomeController> logger, IEmploye repo, IChoix repoChoix, IQuestion repoQuestion,ISousQuestion repoSousQuestion ,ICocherTampon repoCocherTampon, IMapper mapper, ICocher repoCocher)
        {
            _logger = logger;
            this.repo = repo;
            this.repoChoix = repoChoix;
            this.repoQuestion = repoQuestion;
            this.repoSousQuestion = repoSousQuestion;
            this.repoCocherTampon = repoCocherTampon;
            this.mapper = mapper;
            this.repoCocher = repoCocher;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Question(int page, int id)
        {

            ViewData["item"] = id;
            ViewData["page"] = page;

            return View("Question");
        }

        [HttpGet]
        public IActionResult SousQuestion(int page, int id, int nbreChoix)
        {

            ViewData["question"] = page;
            ViewData["numero"] = id;
            ViewData["nbreChoix"] = nbreChoix;

            if (page > 0)
            {
                //rechercher position dans table question

                var position = repoQuestion.noAsynListeQuestion().FirstOrDefault(o=>o.QuestionId == page).Numero_Question;
                ViewData["position"] = position;             
            }
         


          
            return View("SousQuestion");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View("Login");
        }

        public IActionResult Valider()
        {
            return View("Valider");
        }


        public IActionResult Enregistrer(){

            return View("Enregistrer");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> Questions()
        {
            var response = new Reponse<Question>();
            response.Data = await repoQuestion.ListeQuestion();
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SousQuestion>>> SousQuestions()
        {
            var response = new Reponse<SousQuestion>();
            response.Data = await repoSousQuestion.ListeSousQuestion();
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PageRqDto>>> LotSousQuestions()
        {
            
            var response = new Reponse<PageRqDto>();
            var Data = await repoSousQuestion.ListeSousQuestion();
            var lookupResult = Data.ToLookup(v => v.question.QuestionId);         
            IList<PageRqDto> pageRqDtos = new List<PageRqDto>() { };
            int compteur = 1;
            foreach (var group in lookupResult)
            {
                var page = new PageRqDto();
                page.Id = compteur++;

                page.page = group.Key;


                var v = 0;

                foreach (SousQuestion s in group) {
                    v++;
                                 
                }
                page.nbreChoix = v;

                pageRqDtos.Add(page);



            }

            response.Data = pageRqDtos;

                        
            return Ok(response);
        }


        [HttpGet]
        public  ActionResult<PageRqDto> ChoixLotSousQuestions(int page_entre)
        {

            var response = new Reponse<PageRqDto>();
            var Data =  repoSousQuestion.noAsynListeSousQuestion();
            var lookupResult = Data.Where(o=>o.question.QuestionId == page_entre);

            var page = new PageRqDto();

            page.Id = 1;
            page.page = page_entre;
            page.nbreChoix = lookupResult.Count();

            response.OneData = page;


            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CocherTampon>>> ListeCocherTampon(string matricule)
        {
            var response = new Reponse<CocherTampon>();

            if (matricule != null)
            {
                response.Data = await repoCocherTampon.ListeCocherTampon(matricule);
            }


            return Ok(response);
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CocherTampon>>> ListeCocherTamponByPage(string matricule,int page)
        {
            var response = new Reponse<CocherTampon>();

            if (matricule != null)
            {
                response.Data = await repoCocherTampon.ListeCocherTampon(matricule,page);
            }

            return Ok(response);
        }


        [HttpGet]
        public ActionResult<IEnumerable<Cocher>> noAsynListeCocher(string matricule)
        {
            var response = new Reponse<Cocher>();

            if (matricule != null)
            {
                response.Data = repoCocher.noAsynListeCocher(matricule);
            }
            return Ok(response);
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> ChoixQuestions(int id)
        {
            var response = new Reponse<Question>();
            response.Data = await repoQuestion.ListeReponseQuestion(id);
            return Ok(response);
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<SousQuestion>>> ReponseSousQuestion(int numero,int id)
        {
            var response = new Reponse<SousQuestion>();
            response.Data = await repoSousQuestion.ListeSousQuestion();         
            response.OneData = repoSousQuestion.ReponseSousQuestion(numero,id);

            return Ok(response);
        }

       
        [HttpGet]
        public ActionResult<Choix> Choix(int id)
        {
            var reponse = new Reponse<Choix>();

            if (id >= 1)
            {
                reponse.OneData = repoChoix.choix_question(id);
            }
            else
            {
                reponse.OneData = null;
            }

            return Ok(reponse);
        }

        [HttpGet]
        public ActionResult<Question> ChoixQuestion(int id)
        {
            var reponse = new Reponse<Question>();

            if (id >= 1)
            {
                reponse.OneData = repoQuestion.ChoixQuestion(id);
            }
            else
            {

                reponse.OneData = null;
            }



            return Ok(reponse);
        }


        [HttpGet]
        public ActionResult<SousQuestion> ChoixSousQuestion(int numero, int questionid)
        {
            var reponse = new Reponse<SousQuestion>();

            if (questionid >= 1 && numero > 0){
                reponse.OneData = repoSousQuestion.ChoixSousQuestion(numero,questionid);
            }
            else{
                reponse.OneData = null;
            }

            return Ok(reponse);
        }



        [HttpPost]
        public ActionResult ConnexionUtilisateur(int matricule)
        {
           
            var emp = new Employe();
            var reponse = new Reponse<Employe>();

            if (matricule >0)
            {
                var value = matricule;
                
                emp = repo.unEmploye(value);

                //-- vérifier s'il a déjàs participé
                var nbre = 0;
                if(emp != null)
                {
                    //Console.WriteLine(repoCocher.noAsynListeCocher(emp.Matricule));
                    //nbre = repoCocher.noAsynListeCocher(emp.Matricule).Count();
                }


                if(nbre > 0)
                {
                    reponse.Connexion = true;
                    reponse.OneData = emp;
                }
                else
                {
                    reponse.Connexion = false;
                    reponse.OneData = emp;
                }

            }

            if (emp == null)
            {
                RedirectToAction("Index");
            }           


            return Ok(reponse);
        }
          
      
        [HttpPost]
        public ActionResult CocherTampon(CocherTamponRqDto cocherTamponRqDto)
        {
            if (cocherTamponRqDto != null)
            {
                var cocherTampon = mapper.Map<CocherTampon>(cocherTamponRqDto);
                repoCocherTampon.ajouterCocherTampon(cocherTampon);
            }

            return Ok("200");
        }

      
        [HttpPost]
        public IActionResult AjouterCocher([FromBody] CocherRqDto[] cocherRqDto)
        {
            if (cocherRqDto.Count() > 0) {

                foreach (var item in cocherRqDto)
                {
                    var cocher = mapper.Map<Cocher>(item);
                    repoCocher.ajouterCocher(cocher);                     

                }
            }              

            return Ok("200");
        }

       
        [HttpGet]
        public ActionResult FindCocherTamponForDelete(string matricule)
        {
             if(matricule != string.Empty){

                var listCocherTampon = repoCocherTampon.noAsynListeCocherTampon(matricule);

                foreach (var item in listCocherTampon)
                {
                    repoCocherTampon.deleteCocherTampon(item.CocherTamponId);
                }
            }
            return Ok("200");
        }
            

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        #region ------------- AUTRES FONCTIONS ---------------------

       


        #endregion

    }
}
