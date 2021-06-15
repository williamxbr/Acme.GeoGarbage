using System;
using Acme.GeoGarbage.Dominio.Entidades;

namespace Acme.GeoGarbage.Dominio.Interfaces.Servicos
{
    public interface ILastMileageEngineServico : IServicoBase<LastMileageEngine>
    {
        double Odometro(string licenseNumber, DateTime hora);
        double Horimetro(string licenseNumber, DateTime hora);

    }
}