using AutoMapper;
using WebApplication2.DTO;
using WebApplication2.Entities;
namespace WebApplication2
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
            CreateMap<Restaurant, RestaurantDTO>();
            CreateMap<RestaurantDTO, Restaurant>();
        }
    }
}
