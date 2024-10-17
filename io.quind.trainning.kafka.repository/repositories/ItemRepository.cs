using io.quind.trainning.kafka.domain.models;
using io.quind.trainning.kafka.domain.ports.outputs;
using io.quind.trainning.kafka.repository.config;
using io.quind.trainning.kafka.repository.entities;
using Microsoft.EntityFrameworkCore;

namespace io.quind.trainning.kafka.repository.repositories
{
    public class ItemRepository(DatabaseContext databaseContext) : IItemRepository
    {
        public async Task<List<Item>> FindAll()
        {
            return await databaseContext
                .Items
                .Select(item => item.ToItem()).ToListAsync();
        }

        public async Task<Item> FindById(int id)
        {
            try
            {
                var item = await databaseContext.Items.FindAsync(id);
                return item?.ToItem();
            }
            catch (Exception) { throw; }
        }

        public async Task<int> Save(Item item)
        {
            try
            {
                var itemEntity = ItemEntity.From(item);
                await databaseContext.Items.AddAsync(itemEntity);
                await databaseContext.SaveChangesAsync();
                return itemEntity.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> Update(Item item)
        {
            try
            {
                var itemDb = await databaseContext.Items.FindAsync(item.Id);
                if (itemDb != null)
                {
                    itemDb.Quantity = item.Quantity;
                    await Task.Run(() => databaseContext.Items.Update(itemDb));
                    await databaseContext.SaveChangesAsync();
                }
                return item.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
