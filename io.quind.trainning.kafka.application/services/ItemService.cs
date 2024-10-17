using io.quind.trainning.kafka.domain.models;
using io.quind.trainning.kafka.domain.ports.inputs;
using io.quind.trainning.kafka.domain.ports.outputs;

namespace io.quind.trainning.kafka.application.services
{
    public class ItemService : IItemService
    {

        private readonly IItemRepository itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }

        public async Task<int> Create(Item item)
        {
            return await itemRepository.Save(item);
        }

        public async Task<Item> GetItemById(int id)
        {
            return await itemRepository.FindById(id);
        }

        public async Task<List<Item>> GetItems()
        {
            return await itemRepository.FindAll();
        }
    }
}
