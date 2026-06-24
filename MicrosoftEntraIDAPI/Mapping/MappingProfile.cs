using AutoMapper;

namespace MicrosoftEntraIDAPI.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterDto, User>();
        }
    }
}
