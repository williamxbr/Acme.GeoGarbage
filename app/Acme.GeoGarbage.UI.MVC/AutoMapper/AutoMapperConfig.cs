using AutoMapper;

namespace Acme.GeoGarbage.UI.MVC.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DominioParaViewModelMappingProfile>();
                x.AddProfile<ViewModelParaDominioMappingProfile>();
            });
        }
    }
}