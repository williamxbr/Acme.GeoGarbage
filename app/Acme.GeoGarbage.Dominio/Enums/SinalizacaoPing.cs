namespace Acme.GeoGarbage.Dominio.Enums
{
    /// <summary>
    /// Inidica a situação do envio de dados pelo app durante a execução de um setor.
    /// A sinalização utilizará parametro x e y de intervalo e de acordo o tempo em
    /// comparação com o intervalo será inidicado uma situação.
    /// </summary>
    public enum SinalizacaoPing : int
    {


        /// <summary>
        /// Última comunicação inferior a um intervalo de tempo.
        /// </summary>
        Verde = 1,
        /// <summary>
        /// Última comunicação superior a um intervalo x e inferior a um intervalo y.
        /// </summary>
        Amarelo = 2,
        /// <summary>
        /// Última comunicação superior a um intervalo y.
        /// </summary>
        Vermelho = 3,
        /// <summary>
        /// Caso não tenha comunicação entre o setor e o device
        /// </summary>
        Cinza = 4

    }//end SinalizacaoPing

}//end namespace Enums