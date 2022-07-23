using AutoMapper;
using Az204.DAL.Models;

namespace Az204.Domain.DTOs
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
        }
    }
}
