using StudyProject.Domain;
using AutoMapper;

namespace StudyProject.Infrastructure.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Customer, Entidades.Customer>().ReverseMap();
            CreateMap<Endereco, Entidades.Endereco>().ReverseMap();
        }
    }
}
