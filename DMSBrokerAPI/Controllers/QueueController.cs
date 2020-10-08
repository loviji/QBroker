using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DMSBrokerService.Models;
using DMSBrokerService.Operations;
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
        public QueueController(QueueBrokersContext context)
        {
            db = context;
            if (!db.QueueBrokers.Any())
            {
                //test adding
                db.QueueBrokers.Add(new QueueBroker { Function_Name = "rr", Function_Parameter = "23" });
              
                db.SaveChanges();
            } else
            {
                //delete all committed
                var committedOperations = db.QueueBrokers.Where(w => w.Execution_Status == true);
                db.QueueBrokers.RemoveRange(committedOperations);
                db.SaveChanges();
            }
        }
     
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QueueBroker>>> Get()
        {
              return await db.QueueBrokers.ToListAsync();
        }


        //// GET api/QueueBroker/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<QueueBroker>> Get(int id)
        //{
        //    QueueBroker queueBroker = await db.QueueBrokers.FirstOrDefaultAsync(x => x.ID == id);
        //    if (queueBroker == null)
        //        return NotFound();
        //    return new ObjectResult(queueBroker);
        //}


        // POST api/QueueBroker
        [HttpPost]
        public async Task<ActionResult<QueueBroker>> Post(QueueBroker queueBroker)
        {
            if (queueBroker == null)
            {
                return BadRequest();
            }

            db.QueueBrokers.Add(queueBroker);
            await db.SaveChangesAsync();
            QueueOperations qo = new QueueOperations(db);
            qo.AddQueueObject(queueBroker);
            return Ok(queueBroker);
        }


        //// PUT api/users/
        //[HttpPut]
        //public async Task<ActionResult<QueueBroker>> Put(QueueBroker queueBroker)
        //{
        //    if (queueBroker == null)
        //    {
        //        return BadRequest();
        //    }
        //    if (!db.QueueBrokers.Any(x => x.ID == queueBroker.ID))
        //    {
        //        return NotFound();
        //    }

        //    db.Update(queueBroker);
        //    await db.SaveChangesAsync();
        //    return Ok(queueBroker);
        //}

        //// DELETE api/users/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<QueueBroker>> Delete(int id)
        //{
        //    QueueBroker queueBroker = db.QueueBrokers.FirstOrDefault(x => x.ID == id);
        //    if (queueBroker == null)
        //    {
        //        return NotFound();
        //    }
        //    db.QueueBrokers.Remove(queueBroker);
        //    await db.SaveChangesAsync();
        //    return Ok(queueBroker);
        //}
    }
}
