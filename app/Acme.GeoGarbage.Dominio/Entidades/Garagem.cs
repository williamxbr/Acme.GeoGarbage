using System;
using System.Collections.Generic;

namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class Garagem
    {
        public Guid IdGaragem { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public Guid IdCliente { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual IEnumerable<RetornoParaGaragem> RetornosParaGaragens { get; set; }
    }
}
