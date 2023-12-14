using System;
namespace dot_net_api_study.Business.Models
{
	public class Car
	{
		public int id { get; set; }
		public string cor { get; set; }
		public string modelo { get; set; }

		public Car AddModelo(string modelo)
		{
			this.modelo = modelo;
			return this; 
		}
	}
}

