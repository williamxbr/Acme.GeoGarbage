using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.GeoGarbage.Dominio.Enums;

namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class ConsultaDinamicaAssociacao
    {
        public Guid IdConsultaDinamicaAssociacao { get; set; }
        public Guid IdConsultaDinamica { get; set; }
        public Guid IdConstrutorChaveEstrangeira { get; set; }
        public TipoAssociacao TipoAssociacao { get; set; }
        public int Sequencia { get; set; }
        public virtual ConsultaDinamica ConsultaDinamica { get; set; }
        public virtual ConstrutorChaveEstrangeira ConstrutorChaveEstrangeira { get; set; }
    }
}
