using System;

namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class ConsultaDinamica
    {
        public Guid IdConsultaDinamica { get; set; }
        public string NomeConsultaDinamica { get; set; }
        public Guid IdConsultaPasta { get; set; }
        public virtual ConsultaPasta ConsultaPasta { get; set; }
    }
}