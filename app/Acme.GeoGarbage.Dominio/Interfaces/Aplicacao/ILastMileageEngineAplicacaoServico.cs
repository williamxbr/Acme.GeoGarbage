using System;
using Acme.GeoGarbage.Dominio.Entidades;

namespace Acme.GeoGarbage.Dominio.Interfaces.Aplicacao
{
    public interface ILastMileageEngineAplicacaoServico : IAplicacaoServicoBase<LastMileageEngine>
    {
        double Odometro(string licenseNumber, DateTime hora);
        double Horimetro(string licenseNumber, DateTime hora);

    }
}