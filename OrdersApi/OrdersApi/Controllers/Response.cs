namespace OrdersApi.Controllers
{
    public class Response<T>
    {
        public List<T> Objects { get; set; } = new List<T>();

        public int Pages { get; set; }

        public int CurrentPage { get; set; }
    }
}
