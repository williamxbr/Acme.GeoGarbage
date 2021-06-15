using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Repositorios;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Servicos
{
public class DescargaDeColetaServico : ServicoBase<DescargaDeColeta>, IDescargaDeColetaServico
{
private readonly  IDescargaDeColetaRepositorio _descargadecoletaRepositorio;

public DescargaDeColetaServico(IDescargaDeColetaRepositorio descargadecoletaRepositorio) : base(descargadecoletaRepositorio)
{
 _descargadecoletaRepositorio = descargadecoletaRepositorio;
}
}
}
