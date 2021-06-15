using System;
using System.Collections.Generic;
using System.Linq;
using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Repositorios;

namespace Acme.GeoGarbage.Repositorio.Repositorios
{
    public class SetorDaJornadaRepositorio : RepositorioBase<SetorDaJornada>, ISetorDaJornadaRepositorio
    {
        public override SetorDaJornada BuscaId(Guid guid)
        {
            var setor = base.Db.SetorDaJornadas.FirstOrDefault(x => x.IdSetorDaJornada == guid);

            if (setor != null)
            {
                this.ColetarInformacoesComplementaresDeSetor(setor);

                return setor;
            }
            else
            {
                return null;
            }
        }

        public override IEnumerable<SetorDaJornada> BuscaTodos()
        {
            var setores = base.Db.SetorDaJornadas.ToList();

            foreach (var setor in setores)
            {
                this.ColetarInformacoesComplementaresDeSetor(setor);
            }

            return setores;
        }

        protected void ColetarInformacoesComplementaresDeSetor(SetorDaJornada setor)
        {
            var pontosDeColeta = Db.PontoDeColetas.Where(x => x.IdSetor == setor.IdSetor).ToList();
            var pontos = Db.ExecucaoPontoDeColetas.Where(x => x.IdSetorDeJornada == setor.IdSetorDaJornada).ToList();

            for (int i = 0; i < pontos.Count(); i++)
            {
                pontos[i].PontoDeColeta = pontosDeColeta.FirstOrDefault(x => x.IdPontoDeColeta == pontos[i].IdPontoDeColeta);
            }

            setor.Setor = Db.Setors.FirstOrDefault(x => x.IdSetor == setor.IdSetor);
            setor.ExecucaoPontoDeColetas = pontos;
        }
    }
}
