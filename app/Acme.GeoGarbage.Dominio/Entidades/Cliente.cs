using System;
using System.Collections.Generic;
using SQLite;

namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class Cliente
    {
        [PrimaryKey]
        public Guid IdCliente { get; set; }
        public string NomeCliente { get; set; }
        public bool Ativo { get; set; }
        [Ignore]
        public virtual IEnumerable<UsuarioDeCliente> UsuariosDeClientes { get; set; }
        [Ignore]
        public virtual IEnumerable<Garagem> Garagems { get; set; }
        [Ignore]
        public virtual IEnumerable<Setor> Setores { get; set; }
        [Ignore]
        public virtual IEnumerable<Veiculo> Veiculos { get; set; }
        [Ignore]
        public virtual IEnumerable<RecursoDeColeta> RecursosDeColetas { get; set; }
        [Ignore]
        public virtual IEnumerable<ConfiguracaoApp> ConfiguracoesApp { get; set; }
    }
}