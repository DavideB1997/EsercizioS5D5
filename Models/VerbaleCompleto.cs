namespace EsercizioS5D5.Models
{
    public class VerbaleCompleto
    {
        public int IDVerbale { get; set; }
        public DateTime DataViolazione { get; set; }
        public string IndirizzoViolazione { get; set; }
        public string NominativoAgente { get; set; }
        public DateTime DataTrascrizioneVerbale { get; set; }
        public int Importo { get; set; }
        public int DecurtamentoPunti { get; set; }
        public int IDAnagrafica { get; set; }


        public int IDViolazione { get; set; }

        public string Descrizione { get; set; }
        public string Nome {  get; set; }
        public string Cognome { get; set; }

    }
}
