using System.ComponentModel.DataAnnotations;

namespace Acme.GeoGarbage.Dominio.Enums
{
    public enum TipoAgregacao
    {
        [Display(Name = "Nenhum")]
        None = 0,
        [Display(Name = "Média")]
        Avg = 1,
        [Display(Name = "Contar")]
        Count = 2,
        [Display(Name = "Máximo")]
        Max = 3,
        [Display(Name = "Mínimo")]
        Min = 4,
        [Display(Name = "Soma")]
        Sum = 5
    }
}
