using System;
using System.Collections.Generic;
using Acme.GeoGarbage.Dominio.Enums;

namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class Usuario
    {
        public Guid IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public virtual IEnumerable<UsuarioDeCliente> UsuarioDeClientes { get; set; }
        public virtual IEnumerable<UsuarioPerfil> UsuarioPerfils { get; set; }
        public virtual IEnumerable<DeviceInstalado> DeviceInstalados { get; set; }
        public virtual PadraoDaConta PadraoDaContas { get; set; }

    }
}