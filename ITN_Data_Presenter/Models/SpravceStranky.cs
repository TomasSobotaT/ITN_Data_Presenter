using DataDownloader;
using Microsoft.AspNetCore.Mvc;

namespace ITN_Data_Presenter.Models
{
    [Bind]
    public class SpravceStranky
    {
        //seznam všech načtených uživatelů
        public List<User> seznam = new List<User>();

        // vypisovaný seznam do html
        public List<User> Dotaz = new List<User>();      

        

        public bool JenSwww { get; set; } = false;
        
        public bool SeraditJmeno { get; set; } = false;
        public bool JenSFoto { get; set; } = false;


        public SpravceStranky() {  }
       
      
        public void Filtruj()
        {

                Dotaz = seznam.Select(a => a).ToList();

                if (JenSwww)
                {
                    Dotaz = Dotaz.Where(a => (a.Stranka != "")).ToList();
                }

                if (SeraditJmeno)
                {
                    Dotaz = Dotaz.OrderBy(a => a.Jmeno).ToList();
                }

                if (JenSFoto)
                {
                    Dotaz = Dotaz.Where(a => a.ObrazekWWW != "https://www.itnetwork.cz/images/img/person.png").ToList();
                }
        }
    }
}
