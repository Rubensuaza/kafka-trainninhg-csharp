using io.quind.trainning.kafka.domain.models;

namespace io.quind.trainning.kafka.domain.ports.inputs
{
    public interface IItemService
    {
        Task<int> Create(Item item);
        Task<Item> GetItemById(int id);
        Task<List<Item>> GetItems();
       
    }
}
