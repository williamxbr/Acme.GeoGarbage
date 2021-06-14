using System;
using System.Collections.Generic;

namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class ConsultaPasta
    {
        public Guid IdConsultaPasta { get; set; }
        public string NomePasta { get; set; }
        public virtual IEnumerable<ConsultaDinamica> ConsultasDinamicas { get; set; }
    }
}