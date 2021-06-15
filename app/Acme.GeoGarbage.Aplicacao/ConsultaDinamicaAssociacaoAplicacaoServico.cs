using System.Collections.Generic;
using System.Linq;
using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Aplicacao
{
    public class ConsultaDinamicaAssociacaoAplicacaoServico : AplicacaoServicoBase<ConsultaDinamicaAssociacao>, IConsultaDinamicaAssociacaoAplicacaoServico
    {
        private readonly IConsultaDinamicaAssociacaoServico _consultaDinamicaAssociacaoServico;

        public ConsultaDinamicaAssociacaoAplicacaoServico(IConsultaDinamicaAssociacaoServico consultaDinamicaAssociacaoServico)
            : base(consultaDinamicaAssociacaoServico)
        {
            _consultaDinamicaAssociacaoServico = consultaDinamicaAssociacaoServico;
        }

        public void RemoveTodosConsultaDinamicaAssociacao(ConsultaDinamica consultaDinamica)
        {
            IEnumerable<ConsultaDinamicaAssociacao> listaConsultaDinamicaAssociacao = _consultaDinamicaAssociacaoServico
                .BuscaTodos()
                .Where(p => p.IdConsultaDinamica == consultaDinamica.IdConsultaDinamica);

            foreach (ConsultaDinamicaAssociacao consultaDinamicaAssociacao in listaConsultaDinamicaAssociacao)
            {
                _consultaDinamicaAssociacaoServico.Remove(consultaDinamicaAssociacao);
            }

        }
    }
}