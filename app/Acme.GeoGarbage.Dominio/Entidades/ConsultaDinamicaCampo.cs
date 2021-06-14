using System;

namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class ConsultaDinamicaCampo
    {
        public Guid IdConsultaDinamicaCampo { get; set; }
        public Guid IdConsultaDinamica { get; set; }
        public Guid IdConstrutorCampo { get; set; }
        public string ApelidoCampo { get; set; }
        public Enums.Enums.ETipoAgregacao TipoAgregacao { get; set; }
        public virtual ConsultaDinamica ConsultaDinamica { get; set; }
        public virtual ConstrutorCampo ConstrutorCampo { get; set; }
    }
}