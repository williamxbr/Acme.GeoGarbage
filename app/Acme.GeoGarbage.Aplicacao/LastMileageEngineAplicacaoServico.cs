using System;
using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Aplicacao
{
    public class LastMileageEngineAplicacaoServico : AplicacaoServicoBase<LastMileageEngine>, ILastMileageEngineAplicacaoServico
    {
        private readonly ILastMileageEngineServico _lastMileageEngineServico;

        public LastMileageEngineAplicacaoServico(ILastMileageEngineServico lastMileageEngineServico)
            : base(lastMileageEngineServico)
        {
            _lastMileageEngineServico = lastMileageEngineServico;
        }

        public double Horimetro(string licenseNumber, DateTime hora)
        {
            return _lastMileageEngineServico.Horimetro(licenseNumber, hora);
        }

        public double Odometro(string licenseNumber, DateTime hora)
        {
            return _lastMileageEngineServico.Odometro(licenseNumber, hora);
        }
    }
}