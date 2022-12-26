using DataDownloader;
using ITN_Data_Presenter.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ITN_Data_Presenter.Controllers
{
    public class HomeController : Controller
    {

       

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ITNetwork()
        {
            SpravceDB spravceDB = new SpravceDB();
            spravceDB.ZpracujData();
            SpravceStranky spravceStranky = new SpravceStranky();
            spravceStranky.seznam = spravceDB.seznamITN.ToList();
            spravceStranky.Dotaz = spravceDB.seznamITN.ToList();
            return View(spravceStranky);
        }

        [HttpPost]
        public IActionResult ITNetwork(SpravceStranky spravceStranky)
        {
            SpravceDB spravceDB = new SpravceDB();
            spravceDB.ZpracujData();
            spravceStranky.seznam = spravceDB.seznamITN.ToList();
         
            spravceStranky.Filtruj();
            return View(spravceStranky);
        }
    }
}