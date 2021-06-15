using Acme.GeoGarbage.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acme.GeoGarbage.UI.MVC.Areas.Monitoramento.Models
{
    public class ExecucaoPontoDeColetaViewModel
    {

        public ExecucaoPontoDeColetaViewModel()
        {
            this.PontoDeColeta = new PontoDeColetaViewModel();
        }

        public int IdExecucaoPontoDeColeta { get; set; }

        public int IdPontoDeColeta { get; set; }

        public Guid IdSetorDeJornada { get; set; }

        public PontoDeColetaViewModel PontoDeColeta { get; set; }
        
        public StatusDePassagem StatusDePassagem { get; set; }

        public DateTime Passagem { get; set; }
    }
}