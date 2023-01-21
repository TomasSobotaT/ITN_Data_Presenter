using Microsoft.AspNetCore.Mvc;
using System.Data.SQLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITN_Data_Presenter.Models
{
    /// <summary>
    /// Třída načítající uživatele (User) z databáze do seznamu - List<User>
    /// </summary>

    public class SpravceDB
    {
        //connectionstring
        private string pripojovaciString;
        //seznam uzivatelu
        public List<User> seznamITN { get; private set; }


     

        public SpravceDB()
        {
            string adresar = Directory.GetCurrentDirectory();

             pripojovaciString = "Data Source=" + adresar + "\\Database\\Database.sqlite;Version=3;";


            seznamITN = new List<User>();
        }

        public string dejcestu() {return Directory.GetCurrentDirectory(); }

        /// <summary>
        /// Metoda připojí program k databázi a načte hodnoty do paměti
        /// </summary>

        public void ZiskejData()
        {
            using (SQLiteConnection spojeni = new SQLiteConnection(pripojovaciString))
            {

                spojeni.Open();
                string dotaz = "SELECT * FROM ITN_Users";

                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(dotaz, spojeni))
                using (DataSet vysledky = new DataSet())
                {
                    adapter.Fill(vysledky);

                    string jmeno;
                    string obrazekWWW;
                    string stranka;
                    int id;
                    int vek;
                    int zkusenost;
                    int aura;
                    foreach (DataRow item in vysledky.Tables[0].Rows)
                    {

                        jmeno = item["Jmeno"].ToString();
                        obrazekWWW = item["UrlObrazek"].ToString();
                        stranka = item["Urlwww"].ToString();
                        id = int.Parse(item["IdNaITN"].ToString());
                        vek = int.Parse(item["Vek"].ToString());
                        zkusenost = int.Parse(item["Zkusenost"].ToString());
                        aura = int.Parse(item["Aura"].ToString());

                        seznamITN.Add(new User(jmeno, obrazekWWW, stranka, id, vek, zkusenost, aura));
                    }


                }

            }


        }






    }




}
