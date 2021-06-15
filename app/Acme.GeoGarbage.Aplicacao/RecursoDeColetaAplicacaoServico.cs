using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Aplicacao
{
    public class RecursoDeColetaAplicacaoServico : AplicacaoServicoBase<RecursoDeColeta>, IRecursoDeColetaAplicacaoServico
    {
        private readonly IRecursoDeColetaServico _recursosDeColetaServico;

        public RecursoDeColetaAplicacaoServico(IRecursoDeColetaServico recursosDeColetaServico) : base(recursosDeColetaServico)
        {
            _recursosDeColetaServico = recursosDeColetaServico;
        }
    }
}
