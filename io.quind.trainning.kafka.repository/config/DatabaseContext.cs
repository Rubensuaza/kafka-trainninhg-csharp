using io.quind.trainning.kafka.repository.entities;
using Microsoft.EntityFrameworkCore;

namespace io.quind.trainning.kafka.repository.config
{
    public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
    {
        public DbSet<ItemEntity> Items{ get; set; }
    }
}
