using System;
using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Enums;

namespace Acme.GeoGarbage.UI.MVC.Areas.Relatorio.ViewModels
{
    public class ConsultaDinamicaCampoViewModel
    {
        public Guid IdConsultaDinamicaCampo { get; set; }
        public Guid IdConsultaDinamica { get; set; }
        public Guid IdConstrutorCampo { get; set; }
        public string ApelidoCampo { get; set; }
        public TipoAgregacao TipoAgregacao { get; set; }
        public virtual ConsultaDinamicaViewModel ConsultaDinamica { get; set; }
        public virtual ConstrutorCampoViewModel ConstrutorCampo { get; set; }
    }
}