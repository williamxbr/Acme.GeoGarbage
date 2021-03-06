using System;
using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Enums;

namespace Acme.GeoGarbage.UI.MVC.Areas.Relatorio.ViewModels
{
    public class ConsultaDinamicaCondicaoViewModel
    {
        public Guid IdConsultaDinamincaCondicao { get; set; }
        public Guid IdConsultaDinamica { get; set; }
        public Guid IdConstrutorCampo { get; set; }
        public string Operador { get; set; }
        public string Valor { get; set; }
        public TipoDados TipoDados { get; set; }
        public bool Fixo { get; set; }
        public virtual ConsultaDinamicaViewModel ConsultaDinamica { get; set; }
        public virtual ConstrutorCampoViewModel ConstrutorCampo { get; set; }

    }
}