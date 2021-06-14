using System;
using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Aplicacao
{
    public class ConsultaPastaAplicacaoServico : AplicacaoServicoBase<ConsultaPasta>, IConsultaPastaAplicacaoServico
    {
        private readonly IConsultaPastaServico _consultaPastaServico;

        public ConsultaPastaAplicacaoServico(IConsultaPastaServico consultaPastaServico)
            : base(consultaPastaServico)
        {
            _consultaPastaServico = consultaPastaServico;
        }

        public ConsultaPasta BuscaPorPasta(string pasta)
        {
            return _consultaPastaServico.BuscaPorPasta(pasta);
        }
    }
}