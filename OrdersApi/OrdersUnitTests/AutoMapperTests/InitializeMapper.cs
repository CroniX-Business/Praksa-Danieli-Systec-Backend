using AutoMapper;
using OrdersApi;

namespace OrdersUnitTests.AutoMapperTests
{
    public class InitializeMapper
    {
        public static IMapper Initialize()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });

            return mapperConfig.CreateMapper();
        }
    }
}
