using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Aplicacao
{
    public class DeviceAplicacaoServico : AplicacaoServicoBase<Device>, IDeviceAplicacaoServico
    {
        private readonly IDeviceServico _deviceServico;

        public DeviceAplicacaoServico(IDeviceServico deviceServico) : base(deviceServico)
        {
            _deviceServico = deviceServico;
        }
    }
}
