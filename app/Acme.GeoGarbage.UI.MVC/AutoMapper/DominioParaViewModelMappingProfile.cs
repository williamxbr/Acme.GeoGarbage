using AutoMapper;
using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.UI.MVC.Areas.Admin.ViewModels;
using Acme.GeoGarbage.UI.MVC.Areas.Relatorio.ViewModels;

namespace Acme.GeoGarbage.UI.MVC.AutoMapper
{
    public class DominioParaViewModelMappingProfile : Profile
    {
        public DominioParaViewModelMappingProfile()
        {
            CreateMap<UsuarioViewModel, Usuario>();
            CreateMap<ConstrutorTabelaViewModel, ConstrutorTabela>();
            CreateMap<ConstrutorCampoViewModel, ConstrutorCampo>();
            CreateMap<ConstrutorChaveEstrangeiraViewModel, ConstrutorChaveEstrangeira>();

            CreateMap<ConsultaPastaViewModel, ConsultaPasta>();
            CreateMap<ConsultaDinamicaViewModel, ConsultaDinamica>();
            CreateMap<ConsultaDinamicaTabelaViewModel, ConsultaDinamicaTabela>();
            CreateMap<ConsultaDinamicaCampoViewModel, ConsultaDinamicaCampo>();
            CreateMap<ConsultaDinamicaCondicaoViewModel, ConsultaDinamicaCondicao>();

        }
    }
}