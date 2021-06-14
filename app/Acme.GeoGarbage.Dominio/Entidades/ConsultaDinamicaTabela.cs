using System;

namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class ConsultaDinamicaTabela
    {
        public Guid IdConsultaDinamicaTabela { get; set; }
        public Guid IdConsultaDinamica { get; set; }
        public Guid IdConstrutorTabela { get; set; }
        public virtual ConsultaDinamica ConsultaDinamica { get; set; }
        public virtual ConstrutorTabela ConstrutorTabela { get; set; }
    }
}