using System;
using Acme.GeoGarbage.Dominio.Enums;

namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class ConsultaDinamicaCondicao
    {
        public Guid IdConsultaDinamicaCondicao { get; set; }
        public Guid IdConsultaDinamica { get; set; }
        public Guid IdConstrutorCampo { get; set; }
        public TipoOperador Operador { get; set; }
        public string Valor { get; set; }
        public TipoDados TipoDados { get; set; }
        public bool Fixo { get; set; }

		public virtual ConsultaDinamica ConsultaDinamica{
			get;
			set;
		}

		public virtual ConstrutorCampo ConstrutorCampo{
			get;
			set;
		}
    }
}