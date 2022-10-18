using Care.MedicineInventory.Service.Entities;
using Care.MedicineInventory.Service.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace Care.MedicineInventory.Service.Repositories
{
    public static class Extensions
    {
        //function
        //registers IMongo database instance
        public static IServiceCollection AddMongo(this IServiceCollection services)
        {
            //transforms id to a more readable way, any guid will be transformed into a string
            BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
            //transforms datetime to a more readable way, any datetime will be transformed into a string
            BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));


            services.AddSingleton(serviceProvider =>
            {
                var configuration = serviceProvider.GetService<IConfiguration>();
                var serviceSettings = configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();
                var mongoDbSettings = configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>();
                var mongoClient = new MongoClient(mongoDbSettings.ConnectionString);
                return mongoClient.GetDatabase(serviceSettings.ServiceName);
            });

            return services;
        }

        //Function
        //registers the repository
        public static IServiceCollection AddRepository<T>(this IServiceCollection services, string collectionName)
            where T : IEntity
        {
            services.AddSingleton<IRepository<T>>(ServiceProvider =>
            {
                var database = ServiceProvider.GetService<IMongoDatabase>();
                return new MongoRepository<T>(database, collectionName);
            });

            return services;
        }
    }
}