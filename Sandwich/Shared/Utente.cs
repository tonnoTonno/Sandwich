using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandwich.Shared
{
    public class Utente
    {
        public string? Nome { get; set; }
        public string? Cognome { get; set; }
        public string? Mail { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        
    }

    public class Test
    {
        public int? IdTest { get; set; }
        public string? creatore { get; set; }
        public bool? Aperto { get; set; }
        public string? Nome { get; set; }
	}

    public class Tentativo
    {
        public int? codiceTentativo { get; set; }
        public string? utente { get; set; }
        public DateTime? dataOraInizio { get; set; }
        public DateTime? dataOraFine { get; set; }
        public int? risulatato{ get; set; }
        public int? IdTest{ get; set; }
        public List<RispostaTentativo> risposte { get; set; }
    }

    public class Opzione
    {
        public int? ProgressivoOpzione { get; set; }
        public string? Testo { get; set; }
        public bool? OpzioneCorretta { get; set; }
        public int? ProgDomanda { get; set; }
        public int? IdTest { get;set; }

    }

    public class Domanda
    {
        public int? Progressivo { get; set; }
        public string? Consegna { get; set; }
        public int? IdTest { get; set; }

        public List<Opzione> Opzioni { get; set; }

    }

    public class Immagine
    {
        public string? CodificaImmagine { get; set; }
        public int? IdDomanda { get; set; }

    }

    public class RispostaTentativo
    {
        public Domanda Domanda { get; set; }
        public Opzione RispostaData { get; set; }
        public bool giusto { get; set; }
    }
}
