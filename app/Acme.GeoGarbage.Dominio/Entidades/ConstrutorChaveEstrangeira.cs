using System;

namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class ConstrutorChaveEstrangeira
    {
        public Guid IdConstrutorChaveEstrangeira { get; set; }
        public Guid IdConstrutorTabela { get; set; }
        public Guid IdConstrutorCampo { get; set; }
        public Guid IdConstrutorTabelaMestre { get; set; }
        public Guid IdConstrutorCampoMestre { get; set; }

        public virtual  ConstrutorTabela ConstrutorTabela { get; set; }
        public virtual ConstrutorCampo ConstrutorCampo { get; set; }
        public virtual ConstrutorTabela ConstrutorTabelaMestre { get; set; }
        public virtual ConstrutorCampo ConstrutorCampoMestre { get; set; }

    }
}