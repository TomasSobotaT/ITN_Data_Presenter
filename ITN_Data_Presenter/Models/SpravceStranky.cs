
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ITN_Data_Presenter.Models
{/// <summary>
/// Třída na práci se seznamem uživatelů a filtrací
/// </summary>
    [Bind]
    public class SpravceStranky
    {
        //Seznam všech načtených uživatelů
        public List<User> seznam = new List<User>();

        // Vyfiltrovaný seznam do view
        public List<User> Dotaz = new List<User>();

        // Vlastnosti ledání
        public bool JenSFoto { get; set; } = false;
        public bool JenSwww { get; set; } = false;

        [BindProperty]
        public string SeraditPodle { get; set; } = "";

        [Display(Name = "Hledaná přezdívka")]
        public string TextFiltr { get; set; } = "";

        //číslo stránky na které bylo kliknuto
        [BindProperty]
        public int CisloStranky { get; set; } = 1;
        

        /// <summary>
        /// Metoda vyfiltruje uživatele na základě vybraných vlastností
        /// </summary>
        public void Filtruj()
        {

            Dotaz = seznam.Select(a => a).ToList();
            // vyfiltrovat jen uživatele co mají stránky
            if (JenSwww)
            {
                Dotaz = Dotaz.Where(a => (a.Stranka != "")).ToList();
            }
            //vyfiltrovat jen uživatele co mají foto
            if (JenSFoto)
            {
                Dotaz = Dotaz.Where(a => a.ObrazekWWW != "https://www.itnetwork.cz/images/img/person.png").ToList();
            }
            // seřadit abecedně podle jména vzestupě
            if (SeraditPodle=="jmeno")
            {
                Dotaz = Dotaz.OrderBy(a => a.Jmeno).ToList();
            }
            // seřadit podle Id vzestupě
            if (SeraditPodle=="id")
            {
                Dotaz = Dotaz.OrderBy(a => a.Id).ToList();
            }
            // seřadit podle věku sestupně
            if (SeraditPodle == "vek")
            {
                Dotaz = Dotaz.OrderByDescending(a => a.Vek).ToList();
            }
            // seřadit podle zkusenosti sestupně
            if (SeraditPodle == "zkusenost")
            {
                Dotaz = Dotaz.OrderByDescending(a => a.Zkusenost).ToList();
            }
            //seřadit podle aury sestupně
            if (SeraditPodle == "aura")
            {
                Dotaz = Dotaz.OrderByDescending(a => a.Aura).ToList();
            }
            // najde uživatele, jejichž jmeno obsahuje text filtru
            if (TextFiltr != "" && TextFiltr is not null)
            {
                Dotaz = Dotaz.Where(a=>a.Jmeno.Contains(TextFiltr)).ToList();
            }

        }

    }
}
