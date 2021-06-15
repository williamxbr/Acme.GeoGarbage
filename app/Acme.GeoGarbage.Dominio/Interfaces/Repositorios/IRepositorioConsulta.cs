using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.GeoGarbage.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioConsulta
    {
        dynamic Lista(Type resultType, string SQL);
        void Dispose();
    }
}
