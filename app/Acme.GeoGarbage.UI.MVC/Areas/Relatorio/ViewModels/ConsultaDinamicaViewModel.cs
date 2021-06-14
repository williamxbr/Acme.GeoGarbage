using System;

namespace Acme.GeoGarbage.UI.MVC.Areas.Relatorio.ViewModels
{
    public class ConsultaDinamicaViewModel
    {
        public Guid IdConsultaDinamica { get; set; }
        public string NomeConsultaDinamica { get; set; }
        public Guid IdConsultaPasta { get; set; }
        public virtual ConsultaPastaViewModel ConsultaPasta { get; set; }
    }
}