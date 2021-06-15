using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Acme.GeoGarbage.Dominio.Enums;

namespace Acme.GeoGarbage.UI.MVC.Areas.Admin.ViewModels
{
    public class UsuarioViewModel
    {
        [Key]
        public Guid IdUsuario { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {0} caracteres")]
        [DisplayName("NOME")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo E-mail")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [EmailAddress(ErrorMessage = "Minimo {0} caracteres")]
        [DisplayName("E-MAIL")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Preencha o campo E-mail")]
        [MaxLength(20, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {0} caracteres")]
        [DisplayName("LOGIN")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Preencha o campo E-mail")]
        [MaxLength(10, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {0} caracteres")]
        [DisplayName("SENHA")]
        public string Senha { get; set; }

        [DisplayName("ATIVO")]
        public bool Ativo { get; set; }

        [DisplayName("TIPO DE USUARIO")]
        public TipoUsuario TipoUsuario { get; set; }

    }
}