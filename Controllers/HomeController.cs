using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using week10.Data;
using week10.Models;


namespace week10.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataAccess dataAccess;

        public HomeController(DataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        public IActionResult Index()
        {
            List<PriceModel> data = dataAccess.GetData();
            return View(data);
        }
    }
}
