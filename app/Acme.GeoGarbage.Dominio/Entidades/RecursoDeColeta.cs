using System;
using System.Collections.Generic;
using Acme.GeoGarbage.Dominio.Enums;
using SQLite;

namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class RecursoDeColeta
    {
        [PrimaryKey]
        public Guid IdRecursoDeColeta { get; set; }
        public int Senha { get; set; }
        public Guid IdCliente { get; set; }
        public string Nome { get; set; }
        public TipoPerfil Perfil { get; set; }
        public bool Ativo { get; set; }
        [Ignore]
        public virtual Cliente Cliente { get; set; }
    }
}
