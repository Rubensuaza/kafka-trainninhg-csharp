using io.quind.trainning.kafka.domain.exceptions;
using io.quind.trainning.kafka.domain.models;

namespace io.quind.trainning.kafka.application.usecases.validations
{
    public class ItemValidation
    {
        public static void Validate(Item item)
        {
            ProductOutStock(item);
        }
        private static void ProductOutStock(Item item)
        {
            if (item.Quantity >= 0) return;
            throw new ItemException($"Item {item.Id} is out of stock ");

        }
    }
}
