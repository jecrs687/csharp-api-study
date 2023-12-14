using Confluent.Kafka;
using dot_net_api_study.Business.Interfaces.Producers;
using dot_net_api_study.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace dot_net_api_study.Business.Producers
{

	public class KafkaProducer:IKafkaProducer
	{
		private readonly IProducer<Null, string> _producer;
		public KafkaProducer(IProducer<Null, string> producer)
		{
			_producer = producer;
		}
		public async Task producer(Car car)
		{
			string carSerialized = System.Text.Json.JsonSerializer.Serialize(car);
			await _producer.ProduceAsync("topic.cars", new Message<Null, string> { 
			Value = carSerialized
			});
		}
	}
}
