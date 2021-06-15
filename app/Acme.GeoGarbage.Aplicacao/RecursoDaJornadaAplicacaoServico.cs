using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Aplicacao
{
public class RecursoDaJornadaAplicacaoServico : AplicacaoServicoBase<RecursoDaJornada>, IRecursoDaJornadaAplicacaoServico
{
private readonly  IRecursoDaJornadaServico _recursosdajornadaServico;

public RecursoDaJornadaAplicacaoServico(IRecursoDaJornadaServico recursosdajornadaServico) : base(recursosdajornadaServico)
{
_recursosdajornadaServico = recursosdajornadaServico;
}
}
}
