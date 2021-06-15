using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acme.GeoGarbage.UI.MVC.Areas.Monitoramento.Models
{
    public class PontoDeColetaViewModel
    {
        public int IdPontoDeColeta { get; set; }
        
        public int SequenciaDeColeta { get; set; }

        public string Nome { get; set; }

        public float Latitude { get; set; }

        public float Longitude { get; set; }

        public string Horario { get; set; }

        public int Tolerancia1 { get; set; }

        public int Tolerancia2 { get; set; }

        public Guid IdSetor { get; set; }

    }
}