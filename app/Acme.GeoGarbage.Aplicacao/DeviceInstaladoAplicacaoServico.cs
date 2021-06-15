using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Aplicacao
{
    public class DeviceInstaladoAplicacaoServico : AplicacaoServicoBase<DeviceInstalado>, IDeviceInstaladoAplicacaoServico
    {
        private readonly IDeviceInstaladoServico _deviceinstaladoServico;

        public DeviceInstaladoAplicacaoServico(IDeviceInstaladoServico deviceinstaladoServico) : base(deviceinstaladoServico)
        {
            _deviceinstaladoServico = deviceinstaladoServico;
        }
    }
}
