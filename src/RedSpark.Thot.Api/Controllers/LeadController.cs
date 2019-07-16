using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RedSpark.Thot.Api.Models;
using ErrorMessage = RedSpark.Thot.Api.Const.ErrorMessage.Product;


namespace RedSpark.Thot.Api.Controllers
{
    // Obs: Mudando minha rota para "api/leads" e NÃO usando o nome do controller "lead"
    [Route("api/leads")]
    [ApiController]
    public class LeadController : ControllerBase
    {

        private ICollection<LeadSummary> Leads { get; }

        public LeadController(ICollection<LeadSummary> leads)
        {
            Leads = leads;
        }

        // GET: api/Leads
        [HttpGet]
        public IEnumerable<LeadSummary> Get()
        {
            return Leads;
        }

        // GET: api/Leads/5
        [HttpGet("{id}")]
        public ActionResult<LeadSummary> Get(int id)
        {
            var lead = Find(id);

            if (lead == null)
            {
                return NotFound();
            }

            return Ok(lead);
        }

        // POST: api/Leads
        [HttpPost]
        public ActionResult Post([FromBody] LeadSummary lead)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            lead.Id = Leads.Count + 1;
            lead.UpdateDate = DateTime.Now;
            Leads.Add(lead);

            return CreatedAtAction(nameof(Post), lead);
        }

        // PUT: api/Leads/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] LeadSummary leadNew)
        {
            if (!leadNew.CanUpdate())
            {
                return BadRequest();
            }

            var lead = Find(id);

            if (lead == null)
            {
                return NotFound();
            }

            lead.Title = leadNew.Title;
            lead.Status = leadNew.Status;
           
            return Ok(lead);
        }

        // DELETE: api/Leads/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var lead = Find(id);

            if (lead == null)
            {
                return NotFound();
            }

            Leads.Remove(lead);

            return Ok(lead);
        }


        private LeadSummary Find(int id)
        {
            return Leads.SingleOrDefault(p => p.Id.Equals(id));
        }
    }
}
