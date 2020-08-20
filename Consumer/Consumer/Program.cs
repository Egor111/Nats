namespace Consumer
{
    using BasicFunctionality.Services;
    using NATS.Client;

    public class Program
    {
        static void Main(string[] args)
        {
            var natsService = new NatsService();
            natsService.StartNats();
        }
    }
}
