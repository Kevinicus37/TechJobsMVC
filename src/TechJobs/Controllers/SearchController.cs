using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            ViewBag.searchTerm = "";
            ViewBag.check = "all";
            return View();
        }

        [Route("/Search")]
        [HttpPost]
        public IActionResult Results(string searchType, string searchTerm)
        {
            List<Dictionary<string, string>> jobs;
            ViewBag.columns = ListController.columnChoices;
            ViewBag.searchTerm = searchTerm;
            ViewBag.check = searchType;

            if (searchType.Equals("all"))
            {
                jobs = JobData.FindByValue(searchTerm);
                ViewBag.title = string.Format("Results for '{0}' in all categories", searchTerm);
            }
            else
            {
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.title = string.Format("Results for '{0}' within the {1} category", searchTerm, ListController.columnChoices[searchType]);
            }

            ViewBag.jobs = jobs;
            return View("Index");

        }
        // TODO #1 - Create a Results action method to process 
        // search request and display results

    }
}
