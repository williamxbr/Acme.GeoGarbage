using System;
using System.Collections.Generic;
using SQLite;

namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class Garagem
    {
        [PrimaryKey]
        public Guid IdGaragem { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public Guid IdCliente { get; set; }
        [Ignore]
        public virtual Cliente Cliente { get; set; }
        [Ignore]
        public virtual IEnumerable<RetornoParaGaragem> RetornosParaGaragens { get; set; }
    }
}
