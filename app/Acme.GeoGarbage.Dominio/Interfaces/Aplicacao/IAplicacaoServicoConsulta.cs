using System;
using System.Collections;
using System.Collections.Generic;

namespace Acme.GeoGarbage.Dominio.Interfaces.Aplicacao
{
    public interface IAplicacaoServicoConsulta
    {
        dynamic Lista(Type resultType, string SQL);
        void Dispose();
    }
}