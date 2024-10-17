using io.quind.trainning.kafka.application.services;
using io.quind.trainning.kafka.domain.ports.inputs;
using io.quind.trainning.kafka.domain.ports.outputs;
using io.quind.trainning.kafka.repository.repositories;

namespace io.quind.trainning.kafka.config
{
    public class DependencyInjectionConf
    {
        public static void DependencyInjectionConfServices(IServiceCollection services)
        {
            services.AddTransient<IItemRepository, ItemRepository>();
            services.AddTransient<IItemService, ItemService>();           
        }
    }
}
