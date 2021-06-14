using System;

namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class ConsultaDinamicaCondicao
    {
        public Guid IdConsultaDinamincaCondicao { get; set; }
        public Guid IdConsultaDinamica { get; set; }
        public Guid IdConstrutorCampo { get; set; }
        public string Operador { get; set; }
        public string Valor { get; set; }
        public Enums.Enums.ETipoDados TipoDados { get; set; }
        public bool Fixo { get; set; }
        public virtual ConsultaDinamica ConsultaDinamica { get; set; }
        public virtual ConstrutorCampo ConstrutorCampo { get; set; }

    }
}