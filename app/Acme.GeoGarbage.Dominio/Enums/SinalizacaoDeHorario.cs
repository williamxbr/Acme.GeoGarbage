namespace Acme.GeoGarbage.Dominio.Enums
{
    /// <summary>
    /// Sinaliza com uma lista de cores a situação de cumprimento de horário para os
    /// pontos de coleta.
    /// </summary>
    public enum SinalizacaoDeHorario : int
    {


        /// <summary>
        /// Nenhum dos pontos de coleta possui horário configurado.
        /// </summary>
        SemMonitoramento = 0,
        Cinza = 1,
        Verde = 2,
        Amarelo = 3,
        Vermelho = 4,
        Laranja = 5,
        Preto = 6

    }//end SinalizacaoDeHorario

}//end namespace Enums