using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RedSpark.Thot.Api.Domain.Interfaces;
using RedSpark.Thot.Api.Domain.Interfaces.Repositories;
using RedSpark.Thot.Api.Models.Lead.Output;

namespace RedSpark.Thot.Api.Controllers
{
    // Obs: Mudando minha rota para "api/leads" e NÃO usando o nome do controller "lead"
    [Route("api/leads")]
    [ApiController]
    public class LeadController : ControllerBase
    {

        private readonly ILeadRepository _leadRepository;

        public LeadController(ILeadRepository leadRepository)
        {
            _leadRepository = leadRepository;
        }

        // GET: api/Leads?isFollowing=true
        [HttpGet]
        public ActionResult<IEnumerable<LeadSummary>> Get([FromQuery] bool? isFollowing = null)
        {
            //var leads = default(IEnumerable<LeadSummary>);
            var leads = new List<LeadSummary>(); //_leadRepository.GetAll(l => l.);
            
            return Ok(leads);
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

            
            lead.UpdateDate = DateTime.Now;

            //_leadRepository.Create(lead);

            return CreatedAtAction(nameof(Post), lead);
        }

        // PUT: api/Leads/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] LeadSummary leadNew)
        {
            //if (!_leadRepository.Update(id, leadNew))
            //{
            //    return NotFound();
            //}
           
            return Ok(leadNew);
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

             //_leadRepository.Delete(lead);

            return Ok(lead);
        }


        private LeadSummary Find(int id)
        {
            return new LeadSummary(); // _leadRepository.GetById(id);
        }
    }
}
