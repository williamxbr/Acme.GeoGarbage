using System;
using Acme.GeoGarbage.Dominio.Entidades;

namespace Acme.GeoGarbage.UI.MVC.Areas.Relatorio.ViewModels
{
    public class ConsultaDinamicaTabelaViewModel
    {
        public Guid IdConsultaDinamicaTabela { get; set; }
        public Guid IdConsultaDinamica { get; set; }
        public Guid IdConstrutorTabela { get; set; }
        public virtual ConsultaDinamicaViewModel ConsultaDinamica { get; set; }
        public virtual ConstrutorTabelaViewModel ConstrutorTabela { get; set; }
    }
}