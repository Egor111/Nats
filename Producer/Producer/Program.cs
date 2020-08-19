namespace Producer
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Text.Json;
    using System.Threading;
    using BasicFunctionality.DataBase;
    using BasicFunctionality.DataBase.Context;
    using BasicFunctionality.Dto;
    using NATS.Client;

    public class Program
    {
        private static IConnection _connection;
        private static long _countSendMessage = 25;
        private static int _sendIntervalMlSecond = 1000;

        static void Main(string[] args)
        {
            using (_connection = ConnectToNats())
            {
                using (var _context = new ApplicationDbContext())
                {
                    while (_countSendMessage > 0)
                    {
                        var data = GetData(_context);

                        var entity = ProcessData(data);

                        var message = CreateMessage(entity);

                        Publish(message);

                        Save(_context, entity);

                        Thread.Sleep(_sendIntervalMlSecond);

                        _countSendMessage--;
                    }
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
        private static void Publish(byte[] message)  
        {        
            _connection.Publish("nats.test.pubsub", message);
        }

        /// <summary>
        /// Получение данных из таблицы.
        /// </summary>
        private static NatsModel GetData(ApplicationDbContext _context)
        {
            var data = _context.Set<SendNats>()
                .Select(x => new NatsModel
                {
                    Id = x.Id,
                    HashCode = x.HashCode,
                    Number = x.Number
                })
                .OrderByDescending(x => x.Id)
                .FirstOrDefault();

            return data;
        }

        /// <summary>
        /// Обработка данных.
        /// </summary>
        private static SendNats ProcessData(NatsModel model)
        {
            if (model == null)
            {
                var entity = new SendNats
                {
                    Number = 0,
                    HashCode = model.GetHashCode(),
                    SendTime = DateTime.Now,
                    Text = $"Что то во время {DateTime.Now}"
                };

                return entity;
            }

            var sendNats = new SendNats
            {
                Number = model.Number ++,
                HashCode = model.HashCode ++,
                SendTime = DateTime.Now,
                Text = $"Что то во время {DateTime.Now}"
            };

            return sendNats;
        }

        /// <summary>
        /// Сохранение данных в таблицу.
        /// </summary>
        private static void Save(ApplicationDbContext _context, SendNats entity)
        {
            _context.Set<SendNats>().Add(entity);
            _context.SaveChanges();
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
