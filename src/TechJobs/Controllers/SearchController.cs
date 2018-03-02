using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;


namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            ViewBag.searchOptionChecked = "all";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results

        public IActionResult Results(string searchTerm, string searchType)
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = searchType;
            if (searchType == "all" && searchTerm != null)
            {
                ViewBag.jobs = JobData.FindByValue(searchTerm);
            }
            else if (searchType != "all" && searchTerm != null)
            {
                ViewBag.jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
            }
            ViewBag.searchOptionChecked = searchType;
            return View("Index");
        }


    }
}
