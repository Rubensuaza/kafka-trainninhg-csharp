using io.quind.trainning.kafka.domain.models;

namespace io.quind.trainning.kafka.domain.ports.outputs
{
    public interface IItemRepository
    {
        Task<int> Save(Item item);
        Task<Item> FindById(int id);
        Task<List<Item>> FindAll();
        Task<int> Update(Item item);
    }
}
