using Confluent.Kafka;
using dot_net_api_study.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dot_net_api_study.Business.Interfaces.Producers
{

	public interface IKafkaProducer
	{
		Task producer(Car car);

	}


}
