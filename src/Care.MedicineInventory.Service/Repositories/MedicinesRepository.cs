using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Care.MedicineInventory.Service.Entities;
using MongoDB.Driver;

namespace Care.MedicineInventory.Service.Repositories
{

    public class MedicinesRepository : IMedicinesRepository
    {
        // represents a group of objects in mongodb
        // in a relational database would a collection be a table
        private const string collectionName = "medicines";

        //represents the actual mongodb collection
        private readonly IMongoCollection<Medicine> dbCollection;

        //filterbuilder to be able to query for medicines in mongodb
        private readonly FilterDefinitionBuilder<Medicine> filterBuilder = Builders<Medicine>.Filter;

        //constructor
        public MedicinesRepository(IMongoDatabase database)
        {
            dbCollection = database.GetCollection<Medicine>(collectionName);
        }

        //method to return all items in database
        public async Task<IReadOnlyCollection<Medicine>> GetAllAsync()
        {
            return await dbCollection.Find(filterBuilder.Empty).ToListAsync();
        }

        //method to return specific medicine in database
        public async Task<Medicine> GetAsync(Guid id)
        {
            FilterDefinition<Medicine> filter = filterBuilder.Eq(entity => entity.Id, id);
            return await dbCollection.Find(filter).FirstOrDefaultAsync();
        }

        //create (adding) new medicine into the database
        public async Task CreateAsync(Medicine entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await dbCollection.InsertOneAsync(entity);
        }

        //update medicine item in database
        public async Task UpdateAsync(Medicine entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            FilterDefinition<Medicine> filter = filterBuilder.Eq(existingEntity => existingEntity.Id, entity.Id);
            await dbCollection.ReplaceOneAsync(filter, entity);
        }

        //delete medicine item in database
        public async Task RemoveAsync(Guid id)
        {
            FilterDefinition<Medicine> filter = filterBuilder.Eq(entity => entity.Id, id);
            await dbCollection.DeleteOneAsync(filter);
        }
    }
}