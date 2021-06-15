using System;
using System.Collections.Generic;
using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Repositorios;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Servicos
{
    public class ConsultaPastaServico : ServicoBase<ConsultaPasta>, IConsultaPastaServico
    {
        private readonly IConsultaPastaRepositorio _consultaPastaRepositorio;

        public ConsultaPastaServico(IConsultaPastaRepositorio consultaPastaRepositorio)
            : base(consultaPastaRepositorio)
        {
            _consultaPastaRepositorio = consultaPastaRepositorio;
        }

        public ConsultaPasta BuscaPorPasta(string pasta)
        {
            return _consultaPastaRepositorio.BuscaPorPasta(pasta);
        }

        public IEnumerable<ConsultaPasta> BuscaTodosComItens()
        {
            return _consultaPastaRepositorio.BuscaTodosComItens();
        }
    }
}