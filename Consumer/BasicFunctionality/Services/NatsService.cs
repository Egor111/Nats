namespace BasicFunctionality.Services
{
    using BasicFunctionality.DataBase;
    using BasicFunctionality.Model;
    using BasicFunctionality.Repository;
    using NATS.Client;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;

    public class NatsService
    {
        private static bool _exit = false;
        private IConnection _connection;
        private List<SendModel> SendModels = new List<SendModel>();
        private readonly NatsRepository _repository;

        public NatsService()
        {
            _repository = new NatsRepository();
        }

        /// <summary>
        /// Запуск прослушивания.
        /// </summary>
        public void StartNats()
        {
            _connection = ConnectToNats();

            try
            {
                Subscribe();

                SaveMessage();

                SubscribeClear();

                _exit = true;

                _connection.Drain(5000);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
            finally 
            {
                _connection.Close();
            }
        }

        private void Subscribe()
        {
            Task.Run(() =>
            {
                ISyncSubscription sub = _connection.SubscribeSync("nats.test.pubsub");
                while (!_exit)
                {
                    var message = sub.NextMessage();
                    if (message != null)
                    {
                        var data = GetEntityForMessage<SendModel>(message.Data);
                        SendModels.Add(data);
                    }
                }
            });

        }

        /// <summary>
        /// Преобразование сообшения в сущность RecipientNats.
        /// </summary>
        /// <returns></returns>
        private List<RecipientNats> ProcessData()
        {
            var models = SendModels.OrderBy(x => x.Number).ToList();
            var entities = new List<RecipientNats>();

            foreach (var model in models)
            {
                var entity = new RecipientNats
                {
                    Numbet = model.Number,
                    HashCode = model.HashCode,
                    RecipientTime = DateTime.Now,
                    Text = model.Text
                };

                entities.Add(entity);
            }

            return entities;
        }

        /// <summary>
        /// Сохранения сообщения в БД.
        /// </summary>
        private void SaveMessage()
        {
            var entities = ProcessData();

            _repository.Create(entities);
        }

        /// <summary>
        /// Преобразование из byte[] в объекта.
        /// </summary>
        private T GetEntityForMessage<T>(byte[] ansver) where T : class
        {
            var message = Encoding.UTF8.GetString(ansver);

            var entity = JsonSerializer.Deserialize<T>(message);

            return entity;
        }

        /// <summary>
        /// Получение подключения к nats.
        /// </summary>
        private IConnection ConnectToNats()
        {
            ConnectionFactory factory = new ConnectionFactory();

            var options = ConnectionFactory.GetDefaultOptions();
            options.Url = "nats://localhost:4222";

            return factory.CreateConnection(options);
        }

        private void SubscribeClear()
        {
            IAsyncSubscription s = _connection.SubscribeAsync(
                "nats.test.clear");
        }
    }
}
