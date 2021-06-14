using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Acme.GeoGarbage.UI.MVC.Areas.Relatorio.ViewModels
{
    public class ConstrutorChaveEstrangeiraViewModel
    {
        [Key]
        public Guid IdConstrutorChaveEstrangeira { get; set; }
        public Guid IdConstrutorTabela { get; set; }
        public Guid IdConstrutorCampo { get; set; }
        public Guid IdConstrutorTabelaMestre { get; set; }
        public Guid IdConstrutorCampoMestre { get; set; }

        public virtual ConstrutorTabelaViewModel ConstrutorTabela { get; set; }
        public virtual ConstrutorCampoViewModel ConstrutorCampo { get; set; }
        public virtual ConstrutorTabelaViewModel ConstrutorTabelaMestre { get; set; }
        public virtual ConstrutorCampoViewModel ConstrutorCampoMestre { get; set; }
    }
}