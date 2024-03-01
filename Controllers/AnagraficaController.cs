using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using EsercizioS5D5.Models;
using Microsoft.AspNetCore.Mvc.Razor;
using static System.Formats.Asn1.AsnWriter;

namespace EsercizioS5D5.Controllers
{
    public class AnagraficaController : Controller
    {
        private string connString = "Server=EVA\\SQLEXPRESS; Initial Catalog=Esercizio5; Integrated Security=true; TrustServerCertificate=True";

        [HttpGet]
        public IActionResult Index()
        {
           List<Anagrafica> trasgressori = new List<Anagrafica>();

           try
            {
                using (var conn = new SqlConnection(connString))
                {
                    conn.Open();
                    var command = new SqlCommand("SELECT * FROM Anagrafica", conn);

                    using (var reader = command.ExecuteReader())
                    {
                        if(reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var trasgressore = new Anagrafica()
                                {
                                    IDAnagrafica = (int)reader["IDAnagrafica"],
                                    Nome = reader["Nome"].ToString(),
                                    Cognome = reader["Cognome"].ToString(),
                                    Indirizzo = reader["Indirizzo"].ToString(),
                                    Citta = reader["Citta"].ToString(),
                                    CAP = reader["CAP"].ToString(),
                                    Cod_Fisc = reader["Cod_Fisc"].ToString(),
                                };
                                trasgressori.Add(trasgressore);
                            }
                        }
                       
                    }
                }
            }
            catch (Exception ex)
            {
                return View("Error");
            }

            return View(trasgressori);
        }



        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Anagrafica trasgressore)
        {
            bool error = true;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT INTO ANAGRAFICA (Cognome, Nome, Indirizzo, Citta, CAP, Cod_Fisc) 
                 VALUES (@cognome, @nome, @indirizzo, @citta, @cap, @cod_fisc)";

                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@cognome", trasgressore.Cognome);
                        command.Parameters.AddWithValue("@nome", trasgressore.Nome);
                        command.Parameters.AddWithValue("@indirizzo", trasgressore.Indirizzo);
                        command.Parameters.AddWithValue("@citta", trasgressore.Citta);
                        command.Parameters.AddWithValue("@cap", trasgressore.CAP);
                        command.Parameters.AddWithValue("@cod_fisc", trasgressore.Cod_Fisc);

                        command.ExecuteNonQuery();
                        error = false;
                    }
                }
                catch (Exception ex)
                {
                    Console.Write(ex.ToString());
                }
                finally
                {
                    conn.Close();
                }
            }

            if (error)
            {
                return View("Error");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }




    }
}
