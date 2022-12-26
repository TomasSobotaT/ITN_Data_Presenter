using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDownloader
{
    /// <summary>
    /// Třída načítající uživatele (User) z databáze do seznamu - List<User>
    /// </summary>
    internal class SpravceDB
    {
        //connectionstring
        private string pripojovaciString;
        //seznam uzivatelu
        public List<User> seznamITN { get; private set; }

        public SpravceDB()
        {
            string adresar = Directory.GetCurrentDirectory();
            pripojovaciString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + adresar + "\\Database\\Database.mdf;Integrated Security=True";
            seznamITN = new List<User>();
        }


        /// <summary>
        /// Metoda připojí program k databázi a načte hodnoty do paměti
        /// </summary>
        public void ZpracujData()
        {
            using (SqlConnection spojeni = new SqlConnection(pripojovaciString))
            {

                spojeni.Open();
                string dotaz = "SELECT * FROM ITN_Users";

                using (SqlDataAdapter adapter = new SqlDataAdapter(dotaz, spojeni))
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
