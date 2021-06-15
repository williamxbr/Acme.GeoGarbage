using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acme.GeoGarbage.UI.MVC.Areas.Monitoramento.Models
{
    public class MonitoramentoDeColetaViewModel
    {
        public string IdSetor { get; set; }

        public string Setor { get; set; }

        public string Status { get; set; }

        public SinalizacaoDeHorario Horario { get; set; }

        public List<ExecucaoPontoDeColetaViewModel> ServicoEmExecucao { get; set; }

        public int PorcentagemDeConclusao { get; set; }

        public SinalizacaoPing Ping { get; set; }
    }
}