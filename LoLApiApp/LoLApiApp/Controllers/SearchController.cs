using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LoLApiApp.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index(string region, string summonername)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("","");
            return View();
        }
    }
}