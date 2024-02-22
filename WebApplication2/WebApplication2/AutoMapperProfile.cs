using AutoMapper;
using WebApplication2.Entities;
using WebApplication2.DTO;

namespace WebApplication2
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Restaurant, RestaurantDTO>();

            CreateMap<RestaurantDTO, Restaurant>();
        }
    }
}
