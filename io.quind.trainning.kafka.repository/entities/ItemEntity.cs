using io.quind.trainning.kafka.domain.models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace io.quind.trainning.kafka.repository.entities
{
    [Table(name: "tbl_item")]
    public class ItemEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("order_point")]
        public int OrderPoint { get; set; }

        public Item ToItem()
        {
            return new Item
            {
                Id = this.Id,               
                Quantity = this.Quantity,
                OrderPoint = this.OrderPoint
            };
        }

        public static ItemEntity From(Item item)
        {
            return new ItemEntity
            {
                Id = item.Id,                
                Quantity = item.Quantity,
                OrderPoint = item.OrderPoint
            };
        }
    }
}
