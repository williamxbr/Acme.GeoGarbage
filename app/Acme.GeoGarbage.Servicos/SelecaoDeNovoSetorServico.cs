using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Repositorios;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Servicos
{
public class SelecaoDeNovoSetorServico : ServicoBase<SelecaoDeNovoSetor>, ISelecaoDeNovoSetorServico
{
private readonly  ISelecaoDeNovoSetorRepositorio _selecaodenovosetorRepositorio;

public SelecaoDeNovoSetorServico(ISelecaoDeNovoSetorRepositorio selecaodenovosetorRepositorio) : base(selecaodenovosetorRepositorio)
{
 _selecaodenovosetorRepositorio = selecaodenovosetorRepositorio;
}
}
}
