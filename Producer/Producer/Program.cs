namespace Producer
{
    using System;
    using System.Text;
    using System.Text.Json;
    using System.Threading;
    using NATS.Client;
    using STAN.Client;

    class Program
    {
        private static IConnection _connection;
        private static long _countSendMessage = 25;
        private static int _sendIntervalMlSecond = 1000;

        static void Main(string[] args)
        {
            Console.Clear();

            Console.WriteLine("Выберите действие");
            Console.WriteLine("r) Запустить");
            Console.WriteLine("q) Прекратить");

            using (_connection = ConnectToNats())
            {
                while (_countSendMessage > 0)
                {
                    Publish();

                    _countSendMessage--;
                }

                Clear();
                _connection.Drain(5000);
            }
        }

        /// <summary>
        /// Получение подключения к nats.
        /// </summary>
        private static IConnection ConnectToNats()
        {
            ConnectionFactory factory = new ConnectionFactory();

            var options = ConnectionFactory.GetDefaultOptions();
            options.Url = "nats://localhost:4222";
            options.ReconnectWait = 500;

            return factory.CreateConnection(options);
        }

        /// <summary>
        /// Публикация сообщения.
        /// </summary>
        private static void Publish()
        {
            var entity = new Table
            {
                SendTime = DateTime.Now,
                Text = $"Что то во время {DateTime.Now}"
            };

            var message = CreateMessage(entity);

            _connection.Publish("nats.test.pubsub", message);

            Thread.Sleep(_sendIntervalMlSecond);
        }

        /// <summary>
        /// Преобразование из объекта в byte[].
        /// </summary>
        private static byte[] CreateMessage<T>(T entity) where T : class
        {
            string message = JsonSerializer.Serialize<T>(entity);

            byte[] data = Encoding.UTF8.GetBytes(message);

            return data;
        }

        private static void Clear()
        {
            Console.Clear();
            _connection.Publish("nats.test.clear", null);
        }

    }
}
