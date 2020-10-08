using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DMSBrokerService.Models;
using DMSBrokerService.Operations;
using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DMSBrokerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueueController : ControllerBase
    {
        QueueBrokersContext db;
        QueueOperations qo;
        public QueueController(QueueBrokersContext context)
        {
            db = context;
            if (qo==null)
            {
                qo = new QueueOperations(db);
            }
            
            //if (!db.QueueBrokers.Any())
            //{
            //    //test adding
            //    db.QueueBrokers.Add(new QueueBroker { Function_Name = "rr", Function_Parameter = "23" });
              
            //    db.SaveChanges();
            //} else
            //{
            //    //delete all committed
            //    var committedOperations = db.QueueBrokers.Where(w => w.Execution_Status == true);
            //    db.QueueBrokers.RemoveRange(committedOperations);
            //    db.SaveChanges();
            //}
        }
     
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QueueBroker>>> Get()
        {
            return Ok($"Process good");
            //return await db.QueueBrokers.ToListAsync();
        }

        // POST api/QueueBroker
        [HttpPost]
        public async Task<ActionResult<QueueBroker>> Post(QueueBroker queueBroker)
        {
            if (queueBroker == null)
            {
                return BadRequest();
            }

      
            // QueueOperations qo = new QueueOperations(db);
            // qo.AddQueueObject(queueBroker);
            var jobId = BackgroundJob.Enqueue(() => qo.ExecuteProcedure(queueBroker));
            return Ok($"Job Id {jobId} Completed. SP Executed!");
            //return Ok(queueBroker);
        }
        
    }
}
