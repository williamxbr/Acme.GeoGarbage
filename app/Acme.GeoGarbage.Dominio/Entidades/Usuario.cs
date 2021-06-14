using System;
using System.Collections.Generic;
using static Acme.GeoGarbage.Dominio.Enums.Enums;

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
        public ETipoUsuario TipoUsuario { get; set; }
        public virtual IEnumerable<UsuariosDeCliente> UsuariosDeClientes { get; set; }
        public virtual IEnumerable<UsuariosPerfil> UsuariosPerfils { get; set; }
        public virtual IEnumerable<DeviceInstalado> DeviceInstalados { get; set; }

    }
}