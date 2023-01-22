
using ITN_Data_Presenter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

            ViewBag.CisloStranky = 1;
            SpravceDB spravceDB = new SpravceDB();
            spravceDB.ZiskejData();
            SpravceStranky spravceStranky = new SpravceStranky();
            spravceStranky.seznam = spravceDB.seznamITN.ToList();
            spravceStranky.Dotaz = spravceDB.seznamITN.ToList();
            return View(spravceStranky);
        }

      
        // při odeslání formuláře filtrování nebo při kliknutí na odkaz s číslem stránky (čož také odešle formulář)
        [HttpPost]
        public ActionResult ITNetwork(SpravceStranky spravceStranky)
        {
            SpravceDB spravceDB = new SpravceDB();
            spravceDB.ZiskejData();
            spravceStranky.seznam = spravceDB.seznamITN.ToList();
            ViewBag.CisloStranky = spravceStranky.CisloStranky;


            spravceStranky.Filtruj();
            return View(spravceStranky);
        }





        public IActionResult Statistika() 
        {
            SpravceDB spravceDB = new SpravceDB();
            spravceDB.ZiskejData();
            SpravceStranky spravceStranky = new SpravceStranky();
            spravceStranky.seznam = spravceDB.seznamITN.ToList();
            spravceStranky.Dotaz = spravceDB.seznamITN.ToList();
            return View(spravceStranky);
        }

    }
}