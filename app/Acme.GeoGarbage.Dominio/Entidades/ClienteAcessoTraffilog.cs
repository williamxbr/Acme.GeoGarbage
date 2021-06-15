using System;

namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class ClienteAcessoTraffilog
    {
        public Guid IdCliente { get; set; }
        public string LoginTraffilog { get; set; }
        public string PasswordTraffilog { get; set; }
    }
}