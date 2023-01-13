namespace WebClient.Helper
{
    public class ServicesBookingApi
    {
        public HttpClient Initial()
        {
            var HClient = new HttpClient();
            HClient.BaseAddress = new Uri("http://localhost:5155/");
            return HClient;
        }
    }
}
