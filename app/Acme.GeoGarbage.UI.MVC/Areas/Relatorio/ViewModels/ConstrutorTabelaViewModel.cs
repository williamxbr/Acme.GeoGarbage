using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Acme.GeoGarbage.UI.MVC.Areas.Relatorio.ViewModels
{
    public class ConstrutorTabelaViewModel
    {
        [Key]
        public Guid IdConstrutorTabela { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public virtual IEnumerable<ConstrutorCampoViewModel> ConstrutorCampos { get; set; }
    }
}