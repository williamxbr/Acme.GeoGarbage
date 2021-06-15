using System.ComponentModel;

namespace Acme.GeoGarbage.Dominio.Enums
{/// <summary>
    /// Status de operação da jornada..
    /// </summary>
    public enum StatusDeOperacao : int
    {
        /// <summary>
        /// Deslocamento para o setor.
        /// </summary>
        [Description("Deslocamento para setor")]
        DeslocamentoParaSetor = 1,
        /// <summary>
        /// Em coleta
        /// </summary>
        [Description("Em coleta")]
        EmColeta = 2,
        /// <summary>
        /// Deslocamento Para o Aterro
        /// </summary>
        [Description("Deslocamento para aterro")]
        DeslocamentoParaAterro = 3,
        /// <summary>
        /// Em descarga no Aterro
        /// </summary>
        [Description("Em descarga no aterro")]
        EmDescargaNoAterro = 4,
        /// <summary>
        /// Deslocamento para a Garagem
        /// </summary>
        [Description("Deslocamento para garagem")]
        DeslocamentoParaGaragem = 5,
        /// <summary>
        /// Serviço Interrompido
        /// </summary>
        [Description("Serviço interrompido")]
        ServicoInterrompido = 6,
        /// <summary>
        /// Setor concluido
        /// </summary>
        [Description("Setor concluído")]
        SetorConcluido = 7


    }//end StatusDeOperacao

}//end namespace Enums