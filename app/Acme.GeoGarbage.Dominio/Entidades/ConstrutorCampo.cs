using System;
using System.Collections.Generic;
using Acme.GeoGarbage.Dominio.Enums;

namespace Acme.GeoGarbage.Dominio.Entidades
{
    public class ConstrutorCampo
    {
        public Guid IdConstrutorCampo { get; set; }
        public Guid IdConstrutorTabela { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public TipoDados Tipo { get; set; }
        public bool Selecionavel { get; set; }
        public bool Localizavel { get; set; }
        public bool Ordenavel { get; set; }

        public virtual ConstrutorTabela ConstrutorTabela { get; set; }
        public virtual IEnumerable<ConstrutorChaveEstrangeira> ConstrutorChaveEstrangeiras { get; set; }

    }
}
