using Microsoft.EntityFrameworkCore;
namespace DMSBrokerService.Models
{
    public class QueueBrokersContext: DbContext
    {
    
            public DbSet<QueueBroker> QueueBrokers { get; set; }
            public QueueBrokersContext(DbContextOptions<QueueBrokersContext> options)
                : base(options)
            {
                Database.EnsureCreated();
            }
    
    }
}
