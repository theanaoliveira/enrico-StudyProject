using AutoMapper;
using StudyProject.Domain;

namespace StudyProject.Infrastructure.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Customer, DataAccess.Entidades.Customer>().ReverseMap();
            CreateMap<Endereco, DataAccess.Entidades.Endereco>().ReverseMap();
        }
    }
}
