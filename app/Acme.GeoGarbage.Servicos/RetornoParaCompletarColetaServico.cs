using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Repositorios;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Servicos
{
public class RetornoParaCompletarColetaServico : ServicoBase<RetornoParaCompletarColeta>, IRetornoParaCompletarColetaServico
{
private readonly  IRetornoParaCompletarColetaRepositorio _retornoparacompletarcoletaRepositorio;

public RetornoParaCompletarColetaServico(IRetornoParaCompletarColetaRepositorio retornoparacompletarcoletaRepositorio) : base(retornoparacompletarcoletaRepositorio)
{
 _retornoparacompletarcoletaRepositorio = retornoparacompletarcoletaRepositorio;
}
}
}
