using System;
using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Repositorios;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Servicos
{
    public class LastMileageEngineServico : ServicoBase<LastMileageEngine>, ILastMileageEngineServico
    {
        private readonly ILastMileageEngineRepositorio _lastMileageEngineRepositorio;

        public LastMileageEngineServico(ILastMileageEngineRepositorio lastMileageEngineRepositorio) : base(
            lastMileageEngineRepositorio)
        {
            _lastMileageEngineRepositorio = lastMileageEngineRepositorio;
        }

        public double Horimetro(string licenseNumber, DateTime hora)
        {
            return _lastMileageEngineRepositorio.Horimetro(licenseNumber, hora);
        }

        public double Odometro(string licenseNumber, DateTime hora)
        {
            return _lastMileageEngineRepositorio.Odometro(licenseNumber, hora);
        }
    }
}