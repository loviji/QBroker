using DMSBrokerService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMSBrokerService.Operations
{
    public class QueueOperations
    {
        
        QueueBrokersContext db;
        public QueueOperations(QueueBrokersContext context)
        {
            db = context;
        }


        //public void AddQueueObject(QueueBroker qb)
        //{
        //    q.Enqueue(qb);
        //}

        //public void SetCommittedToQueueObject(int id)
        //{
        //    try
        //    {
        //        QueueBroker qu = db.QueueBrokers.Where(i => i.ID == id).FirstOrDefault();
        //        if (qu != null)
        //        {
        //            qu.Execution_Status = true;
        //            db.SaveChanges();
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        //public void papulateQueueObjectFromDatabase()
        //{
        //    q.Enqueue(db.QueueBrokers.Where(s => s.Execution_Status == false).FirstOrDefault());
        //}

     
        public void ExecuteProcedure(QueueBroker queueBroker)
        {
            db.Database.ExecuteSqlCommand("SP_DMS_UPDATE_DOCUMENT_AUTHORS_FP @p0", parameters: new[] { "12740" });
            Console.WriteLine($"Unsubscribed {queueBroker.Function_Name}");
        }
    }
}
