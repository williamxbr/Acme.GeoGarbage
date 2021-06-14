using Acme.GeoGarbage.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class Setor
    {
        public Guid IdSetor { get; set; }
        public Guid IdCliente { get; set; }
        public string NomeSetor { get; set; }
        public bool Ativo { get; set; }
        public virtual Cliente Clientes { get; set; }
        public virtual IEnumerable<SetoresDaJornada> SetoresDasJornadas { get; set; }
    }
}
