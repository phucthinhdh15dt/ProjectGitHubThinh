

using AutoMapper;
using OrganizationDemo.ModelsClient;

namespace OrganizationDemo.ConfigService.ConfigGenaral
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<test, OrganizationClient>();
            CreateMap<OrganizationClient, test>();
        }
    }
}
