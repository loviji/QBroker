using DMSBrokerService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMSBrokerService.Operations
{
    public class QueueOperations
    {
        Queue<QueueBroker> q;
        QueueBrokersContext db;
        public QueueOperations(QueueBrokersContext context)
        {
            db = context;
            if (q == null)
                q = new Queue<QueueBroker>();
            if (q.Count() == 0)
                papulateQueueObjectFromDatabase();

        }


        public void AddQueueObject(QueueBroker qb)
        {
            q.Enqueue(qb);
        }

        public void SetCommittedToQueueObject(int id)
        {
            try
            {
                QueueBroker qu = db.QueueBrokers.Where(i => i.ID == id).FirstOrDefault();
                if (qu != null)
                {
                    qu.Execution_Status = true;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void papulateQueueObjectFromDatabase()
        {
            q.Enqueue(db.QueueBrokers.Where(s => s.Execution_Status == false).FirstOrDefault());
        }
    }
}
