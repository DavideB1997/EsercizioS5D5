using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using EsercizioS5D5.Models;

namespace EsercizioS5D5.Controllers
{
    public class StatisticheController : Controller
    {
        private string connString = "Server=EVA\\SQLEXPRESS; Initial Catalog=Esercizio5; Integrated Security=true; TrustServerCertificate=True";


        public IActionResult TotaleVerbali()
        {
            List<VerbaleParziale> totaliVerbali = new List<VerbaleParziale>();

            try
            {
                using (var conn = new SqlConnection(connString))
                {
                    conn.Open();
                    var command = new SqlCommand(@"SELECT ANAGRAFICA.Cognome + ' ' + ANAGRAFICA.Nome AS NomeCompleto,
                                                COUNT(*) AS NumeroVerbaliTrascritti
                                            FROM VERBALE
                                            JOIN ANAGRAFICA ON VERBALE.IDAnagrafica = ANAGRAFICA.IDAnagrafica
                                            GROUP BY ANAGRAFICA.Cognome, ANAGRAFICA.Nome", conn);

                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var totaleVerbali = new VerbaleParziale()
                        {
                            NomeCompleto = reader["NomeCompleto"].ToString(),
                            NumeroVerbaliTrascritti = (int)reader["NumeroVerbaliTrascritti"]
                        };

                        totaliVerbali.Add(totaleVerbali);
                    }
                }
            }
            catch (Exception ex)
            {
                // Gestisci l'eccezione
                return View("Error");
            }

            return View(totaliVerbali);
        }


        public IActionResult VerbalePuntiDecurtati()
        {
            List<Trasgressore_Decurtati> totaliPunti = new List<Trasgressore_Decurtati>();

            try
            {
                using (var conn = new SqlConnection(connString))
                {
                    conn.Open();
                    var command = new SqlCommand(@"SELECT ANAGRAFICA.Cognome + ' ' + ANAGRAFICA.Nome AS NomeCompleto,
                                                SUM(VERBALE.DecurtamentoPunti) AS TotalePuntiDecurtati
                                            FROM VERBALE
                                            JOIN ANAGRAFICA ON VERBALE.IDAnagrafica = ANAGRAFICA.IDAnagrafica
                                            GROUP BY ANAGRAFICA.Cognome, ANAGRAFICA.Nome", conn);

                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var totalePunti = new Trasgressore_Decurtati()
                        {
                            NomeCompleto = reader["NomeCompleto"].ToString(),
                            TotalePuntiDecurtati = (int)reader["TotalePuntiDecurtati"]
                        };

                        totaliPunti.Add(totalePunti);
                    }
                }
            }
            catch (Exception ex)
            {
                // Gestisci l'eccezione
                return View("Error");
            }

            return View(totaliPunti);
        }


        public IActionResult VerbaliMaggiore10 ()
        {
            List<VerbaleCompleto> verbaliCompleti = new List<VerbaleCompleto>();

            try
            {
                using (var conn = new SqlConnection(connString))
                {
                    conn.Open();
                    var command = new SqlCommand(@"SELECT VERBALE.*, TIPO_VIOLAZIONE.Descrizione AS Descrizione, ANAGRAFICA.Cognome AS Cognome, ANAGRAFICA.Nome AS Nome FROM VERBALE 
                                        JOIN TIPO_VIOLAZIONE ON VERBALE.IDViolazione = TIPO_VIOLAZIONE.IDViolazione
                                        JOIN ANAGRAFICA ON VERBALE.IDAnagrafica = ANAGRAFICA.IDAnagrafica WHERE VERBALE.DecurtamentoPunti > 10", conn);

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

                        verbaliCompleti.Add(verb);
                    }
                }
            }
            catch (Exception ex)
            {
                // Gestisci l'eccezione
                return View("Error");
            }

            return View("~/Views/Verbale/Index.cshtml", verbaliCompleti);
        }

        public IActionResult VerbaliMaggiore400()
        {
            List<VerbaleCompleto> verbaliCompleti = new List<VerbaleCompleto>();

            try
            {
                using (var conn = new SqlConnection(connString))
                {
                    conn.Open();
                    var command = new SqlCommand(@"SELECT VERBALE.*, TIPO_VIOLAZIONE.Descrizione AS Descrizione, ANAGRAFICA.Cognome AS Cognome, ANAGRAFICA.Nome AS Nome FROM VERBALE 
                                        JOIN TIPO_VIOLAZIONE ON VERBALE.IDViolazione = TIPO_VIOLAZIONE.IDViolazione
                                        JOIN ANAGRAFICA ON VERBALE.IDAnagrafica = ANAGRAFICA.IDAnagrafica WHERE VERBALE.Importo > 400", conn);

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

                        verbaliCompleti.Add(verb);
                    }
                }
            }
            catch (Exception ex)
            {
                // Gestisci l'eccezione
                return View("Error");
            }

            return View("~/Views/Verbale/Index.cshtml", verbaliCompleti);
        }
    }

   
}
    
