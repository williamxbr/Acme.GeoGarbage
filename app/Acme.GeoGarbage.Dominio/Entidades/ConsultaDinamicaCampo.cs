using System;
using Acme.GeoGarbage.Dominio.Enums;

namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class ConsultaDinamicaCampo
    {
        public Guid IdConsultaDinamicaCampo { get; set; }
        public Guid IdConsultaDinamica { get; set; }
        public Guid IdConstrutorCampo { get; set; }
        public string ApelidoCampo { get; set; }
        public TipoAgregacao TipoAgregacao { get; set; }
        public int Apresentacao { get; set; }
        public int Ordenacao { get; set; }
        public virtual ConsultaDinamica ConsultaDinamica { get; set; }
        public virtual ConstrutorCampo ConstrutorCampo { get; set; }
    }
}