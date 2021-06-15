using Acme.GeoGarbage.Dominio.Entidades;
using System;
using System.Collections.Generic;
using SQLite;

namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class Setor
    {
        [PrimaryKey]
        public Guid IdSetor { get; set; }
        public Guid IdCliente { get; set; }
        public string NomeSetor { get; set; }
        public bool Ativo { get; set; }
        [Ignore]
        public virtual Cliente Cliente { get; set; }
        [Ignore]
        public virtual IEnumerable<SetorDaJornada> SetorDaJornadas { get; set; }
        [Ignore]
        public virtual IEnumerable<PontoDeColeta> PontoDeColetas {get;set;}
    }
}
