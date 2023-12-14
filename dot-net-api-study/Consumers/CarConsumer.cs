
using Confluent.Kafka;
using dot_net_api_study.Business.Models;
using Newtonsoft.Json;

namespace dot_net_api_study.Consumers
{
	public class CarConsumer : BackgroundService
	{
		private readonly IConsumer<Null, string> _consumer;

		public CarConsumer(IConsumer<Null, string> consumer)
		{
			_consumer = consumer;
		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			await Task.Yield();
			try
			{
				_consumer.Subscribe("topic.cars");
				while (!stoppingToken.IsCancellationRequested)
				{
					var result = _consumer.Consume(stoppingToken);
					if (result is null || result.IsPartitionEOF || stoppingToken.IsCancellationRequested)
						continue;
					var message = result.Message.Value;
					var response = JsonConvert.DeserializeObject<Car>(message);
					_consumer.Commit(result);
					_consumer.StoreOffset(result);
				}
			}
			catch (Exception)
			{
				_consumer.Close();
				_consumer.Dispose();
			}
		}
	}
}
