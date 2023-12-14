using Confluent.Kafka;
using dot_net_api_study.Business.Configurations;
using dot_net_api_study.Business.Dto.Responses;
using dot_net_api_study.Business.Interfaces.Clients;
using dot_net_api_study.Business.Interfaces.Producers;
using dot_net_api_study.Business.Interfaces.Services;
using dot_net_api_study.Business.Producers;
using dot_net_api_study.Business.Services;
using dot_net_api_study.Consumers;
using System.Net;

var builder = WebApplication.CreateBuilder(args);
var carConfig = new CarConfig();

var configConsumer = new ConsumerConfig
{
	GroupId = "groudid-kafka",
	BootstrapServers = "localhost:9092",
	AutoOffsetReset = AutoOffsetReset.Earliest,
	PartitionAssignmentStrategy = PartitionAssignmentStrategy.RoundRobin,
	EnableAutoCommit = false,
	EnableAutoOffsetStore = false,
	MaxPollIntervalMs = 600000,
	SecurityProtocol = (SecurityProtocol)Enum.Parse(typeof(SecurityProtocol), "Plaintext")
};

var configProducer = new ProducerConfig
{
	BootstrapServers = "localhost:9092",
	ClientId = Dns.GetHostName(),
	SecurityProtocol = (SecurityProtocol)Enum.Parse(typeof(SecurityProtocol), "Plaintext"),
	Partitioner = Partitioner.ConsistentRandom
};
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IKafkaProducer, KafkaProducer>();
builder.Services.AddHttpClient<IGiuseppinBeeceptorClient, GiuseppinBeeceptorClient>();
builder.Configuration.Bind("CarConfig", carConfig);
builder.Services.AddSingleton(carConfig);
builder.Services.AddTransient(_ => new ConsumerBuilder<Ignore, string>(configConsumer).Build());
builder.Services.AddTransient(_ => new ProducerBuilder<Null, string>(configProducer).Build());
builder.Services.AddHostedService<CarConsumer>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

