using AutoMapper;
using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.UI.MVC.Areas.Admin.ViewModels;
using Acme.GeoGarbage.UI.MVC.Areas.Relatorio.ViewModels;

namespace Acme.GeoGarbage.UI.MVC.AutoMapper
{
    public class ViewModelParaDominioMappingProfile : Profile
    {
        public ViewModelParaDominioMappingProfile()
        {
            CreateMap<Usuario, UsuarioViewModel>();
            CreateMap<ConstrutorTabela, ConstrutorTabelaViewModel>();
            CreateMap<ConstrutorCampo, ConstrutorCampoViewModel>();
            CreateMap<ConstrutorChaveEstrangeira, ConstrutorChaveEstrangeiraViewModel>();

            CreateMap<ConsultaPasta, ConsultaPastaViewModel>();
            CreateMap<ConsultaDinamica, ConsultaDinamicaViewModel>();
            CreateMap<ConsultaDinamicaTabela, ConsultaDinamicaTabelaViewModel>();
            CreateMap<ConsultaDinamicaCampo, ConsultaDinamicaCampoViewModel>();
            CreateMap<ConsultaDinamicaCondicao, ConsultaDinamicaCondicaoViewModel>();

        }
    }
}