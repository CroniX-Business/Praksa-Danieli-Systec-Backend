using AutoMapper;
using OrdersApi;

namespace OrdersUnitTests.AutoMapperTest
{
    public static class InitializeMapper
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
