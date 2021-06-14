using System.ComponentModel.DataAnnotations;

namespace Acme.GeoGarbage.Dominio.Enums
{
    public class Enums
    {
        public enum ETipoUsuario
        {
            SmartDrive,
            Cliente
        }

        public enum EPerfil
        {
            Coletor,
            Motorista
        }

        public enum EStatusJornada
        {
            EmAndamento,
            NaoConcluida,
            Finalizada
        }

        public enum ETipoDados
        {
            Texto,
            Numero,
            Datahora
        }

        public enum ETipoAgregacao
        {
            [Display(Name = "Nenhum")]
            None,
            [Display(Name="Média")]
            Avg,
            [Display(Name = "Contar")]
            Count,
            [Display(Name = "Máximo")]
            Max,
            [Display(Name = "Mínimo")]
            Min,
            [Display(Name = "Soma")]
            Sum
        }
    }
}