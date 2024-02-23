using AutoMapper;
using WebApplication2.DTO;
using WebApplication2.Entities;

namespace WebApplication2
{
    public class AutoMapperProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoMapperProfile"/> class.
        /// </summary>
        public AutoMapperProfile() {
            this.CreateMap<Restaurant, RestaurantDTO>().ReverseMap();
        }
    }
}
