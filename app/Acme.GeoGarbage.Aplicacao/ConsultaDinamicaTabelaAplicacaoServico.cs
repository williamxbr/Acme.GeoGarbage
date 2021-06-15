using System.Collections.Generic;
using System.Linq;
using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Aplicacao
{
    public class ConsultaDinamicaTabelaAplicacaoServico : AplicacaoServicoBase<ConsultaDinamicaTabela>, IConsultaDinamicaTabelaAplicacaoServico
    {
        private readonly IConsultaDinamicaTabelaServico _consultaDinamicaTabelaServico;

        public ConsultaDinamicaTabelaAplicacaoServico(IConsultaDinamicaTabelaServico consultaDinamicaTabelaServico)
            : base(consultaDinamicaTabelaServico)
        {
            _consultaDinamicaTabelaServico = consultaDinamicaTabelaServico;
        }

        public void RemoveTodosConsultaDinamicaTabela(ConsultaDinamica consultaDinamica)
        {
            IEnumerable<ConsultaDinamicaTabela> listaConsultaDinamicaTabela = _consultaDinamicaTabelaServico
                .BuscaTodos()
                .Where(p => p.IdConsultaDinamica == consultaDinamica.IdConsultaDinamica);

            foreach (ConsultaDinamicaTabela consultaDinamicaTabela in listaConsultaDinamicaTabela)
            {
                _consultaDinamicaTabelaServico.Remove(consultaDinamicaTabela);
            }
        }
    }
}