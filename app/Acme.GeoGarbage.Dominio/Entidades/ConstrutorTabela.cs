using System;
using System.Collections.Generic;

namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class ConstrutorTabela
    {
        public Guid IdConstrutorTabela { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public virtual IEnumerable<ConstrutorCampo> ConstrutorCampos { get; set; }
        public virtual IEnumerable<ConstrutorChaveEstrangeira> ConstrutorChaveEstrangeiras { get; set; }
    }
}
