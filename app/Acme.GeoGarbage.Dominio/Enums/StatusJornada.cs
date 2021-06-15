using System.ComponentModel;

namespace Acme.GeoGarbage.Dominio.Enums
{
    public enum StatusJornada
    {
        [Description("Em andamento")]
        EmAndamento = 1,
        [Description("Não concluida")]
        NaoConcluida = 2,
        [Description("Finalizada")]
        Finalizada = 3
    }
}
