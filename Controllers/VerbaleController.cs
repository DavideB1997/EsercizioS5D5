using EsercizioS5D5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using System;

namespace EsercizioS5D5.Controllers
{
    public class VerbaleController : Controller
    {
        private string connString = "Server=EVA\\SQLEXPRESS; Initial Catalog=Esercizio5; Integrated Security=true; TrustServerCertificate=True";

        public IActionResult Index()
        {
            List<VerbaleCompleto> verbaleCompleto = new List<VerbaleCompleto>();

            try
            {
                using (var conn = new SqlConnection(connString))
                {
                    conn.Open();
                    var command = new SqlCommand(@"SELECT VERBALE.*, TIPO_VIOLAZIONE.Descrizione AS Descrizione, ANAGRAFICA.Cognome AS Cognome, ANAGRAFICA.Nome AS Nome FROM VERBALE 
                                        JOIN TIPO_VIOLAZIONE ON VERBALE.IDViolazione = TIPO_VIOLAZIONE.IDViolazione
                                        JOIN ANAGRAFICA ON VERBALE.IDAnagrafica = ANAGRAFICA.IDAnagrafica", conn);

                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var verb = new VerbaleCompleto()
                        {
                            IDVerbale = (int)reader["IDVerbale"],
                            IDAnagrafica = (int)reader["IDVerbale"],
                            IDViolazione = (int)reader["IDViolazione"],
                            DataViolazione = (DateTime)reader["DataViolazione"],
                            IndirizzoViolazione = reader["IndirizzoViolazione"].ToString(),
                            NominativoAgente = reader["NominativoAgente"].ToString(),
                            DataTrascrizioneVerbale = (DateTime)reader["DataTrascrizioneVerbale"],
                            Importo = (int)Convert.ToDecimal(reader["Importo"]),
                            DecurtamentoPunti = Convert.ToInt32(reader["DecurtamentoPunti"]),
                            Descrizione = reader["Descrizione"].ToString(),
                            Nome = reader["Nome"].ToString(),
                            Cognome = reader["Cognome"].ToString(),
                        };

                        verbaleCompleto.Add(verb);
                    }
                }
            }
            catch (Exception ex)
            {
                // Gestisci l'eccezione
                return View("Error");
            }

            return View(verbaleCompleto);
        }







        [HttpGet]
        public IActionResult Add()
        {
            List<Violazione> ViolazioniLista = new List<Violazione>();
            List<Anagrafica> AnagraficaLista = new List<Anagrafica>();

            try
            {
                using (var conn = new SqlConnection(connString))
                {
                    conn.Open();
                    var command = new SqlCommand("SELECT IDViolazione, Descrizione FROM TIPO_VIOLAZIONE", conn);
                    var command1 = new SqlCommand("SELECT IDAnagrafica ,Cognome, Nome FROM Anagrafica", conn);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var violazione = new Violazione()
                                {
                                    IDViolazione = (int)reader["IDViolazione"],
                                    Descrizione = reader["Descrizione"].ToString(),
                                };
                                ViolazioniLista.Add(violazione);

                               
                            }
                        }
                    }

                    using (var reader = command1.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var trasgressore = new Anagrafica()
                                {
                                    IDAnagrafica = (int)reader["IDAnagrafica"],
                                    Cognome = reader["Cognome"].ToString(),
                                    Nome = reader["Nome"].ToString(),
                                };
                                AnagraficaLista.Add(trasgressore);
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                // Gestione dell'errore
                return View("Error");
            }

            ViewBag.ViolazioniLista = ViolazioniLista;
            ViewBag.AnagraficaLista = AnagraficaLista;




            return View();
        }


        [HttpPost]
        public IActionResult Add(Verbale verbale)
        {
            bool error = true;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT INTO VERBALE (DataViolazione,IndirizzoViolazione,NominativoAgente,DataTrascrizioneVerbale,Importo,DecurtamentoPunti,IDAnagrafica,IDViolazione)
                VALUES (@dataViolazione,@indirizzoViolazione,@nominativoAgente,@dataTrascrizioneVerbale,@importo,@decurtamentoPunti,@idAnagrafica,@idViolazione)";

                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@dataViolazione", verbale.DataViolazione);
                        command.Parameters.AddWithValue("@indirizzoViolazione", verbale.IndirizzoViolazione);
                        command.Parameters.AddWithValue("@nominativoAgente", verbale.NominativoAgente);
                        command.Parameters.AddWithValue("@dataTrascrizioneVerbale", verbale.DataTrascrizioneVerbale);
                        command.Parameters.AddWithValue("@importo", verbale.Importo);
                        command.Parameters.AddWithValue("@decurtamentoPunti", verbale.DecurtamentoPunti);
                        command.Parameters.AddWithValue("@idAnagrafica", verbale.IDAnagrafica);
                        command.Parameters.AddWithValue("@idViolazione", verbale.IDViolazione);

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
