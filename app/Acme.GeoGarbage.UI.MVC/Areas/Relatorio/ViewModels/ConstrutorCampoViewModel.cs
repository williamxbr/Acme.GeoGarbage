using System;
using System.Collections.Generic;
using Acme.GeoGarbage.Dominio.Enums;

namespace Acme.GeoGarbage.UI.MVC.Areas.Relatorio.ViewModels
{
    public class ConstrutorCampoViewModel
    {
        public Guid IdConstrutorCampo { get; set; }
        public Guid IdConstrutorTabela { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public TipoDados Tipo { get; set; }
        public bool Selecionavel { get; set; }
        public bool Localizavel { get; set; }
        public bool Ordenavel { get; set; }
        public virtual ConstrutorTabelaViewModel ConstrutorTabela { get; set; }
        public virtual IEnumerable<ConstrutorChaveEstrangeiraViewModel> ConstrutorChaveEstrangeiras { get; set; }

    }
}