using System;
using System.Collections.Generic;

namespace Acme.GeoGarbage.UI.MVC.Areas.Relatorio.ViewModels
{
    public class ConsultaPastaViewModel
    {
        public Guid IdConsultaPasta { get; set; }
        public string NomePasta { get; set; }
        public virtual IEnumerable<ConsultaDinamicaViewModel> ConsultasDinamicas { get; set; }
    }
}