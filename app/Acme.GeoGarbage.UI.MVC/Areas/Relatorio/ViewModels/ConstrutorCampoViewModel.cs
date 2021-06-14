using System;

namespace Acme.GeoGarbage.UI.MVC.Areas.Relatorio.ViewModels
{
    public class ConstrutorCampoViewModel
    {
        public Guid IdConstrutorCampo { get; set; }
        public Guid IdConstrutorTabela { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public int Tipo { get; set; }
        public bool Selecionavel { get; set; }
        public bool Localizavel { get; set; }
        public bool Ordenavel { get; set; }
        public virtual ConstrutorTabelaViewModel ConstrutorTabela { get; set; }
    }
}