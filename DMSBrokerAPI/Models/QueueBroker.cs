using System.ComponentModel.DataAnnotations.Schema;

namespace DMSBrokerService.Models
{
    [Table("ERP_QUEUE_BROKER")]
    public class QueueBroker
    {
        public int ID { get; set; }
        public string Function_Name { get; set; }

        public string Function_Parameter { get; set; }
        public bool Execution_Status { get; set; }
    }
}
