using System;
using System.Collections.Generic;

namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class Cliente
    {
        public Guid IdCliente { get; set; }
        public string NomeCliente { get; set; }
        public bool Ativo { get; set; }
        public virtual IEnumerable<UsuariosDeCliente> UsuariosDeClientes { get; set; }
        public virtual IEnumerable<Garagem> Garagems { get; set; }
        public virtual IEnumerable<Setor> Setores { get; set; }
        public virtual IEnumerable<Veiculo> Veiculos { get; set; }
        public virtual IEnumerable<RecursosDeColeta> RecursosDeColetas { get; set; }
        public virtual IEnumerable<ConfiguracaoApp> ConfiguracoesApp { get; set; }
    }
}