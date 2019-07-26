
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using RedSpark.Thot.Api.Application.Interfaces;
using RedSpark.Thot.Api.Application.Models.Lead.Output;
using RedSpark.Thot.Api.Application.Models.Leads.Input;
using RedSpark.Thot.Api.Application.Models.Leads.Output;

namespace RedSpark.Thot.Api.Controllers
{
    // Obs: Mudando minha rota para "api/leads" e NÃO usando o nome do controller "lead"
    [Route("api/leads")]
    [ApiController]
    public class LeadController : ControllerBase
    {

        private readonly ILeadService _leadService;

        public LeadController(ILeadService leadService)
        {
            _leadService = leadService;
        }


        // GET: api/Leads?isFollowing=true
        [HttpGet]
        public ActionResult<IEnumerable<LeadSummaryModel>> Get([FromQuery] bool? isFollowing = null)
        {
            //var leads = default(IEnumerable<LeadSummary>);
            var leads = new List<LeadSummaryModel>(); //_leadRepository.GetAll(l => l.);
            
            return Ok(leads);
        }
               
        // GET: api/Leads/5
        [HttpGet("{id}")]
        public ActionResult<LeadSummaryModel> Get(int id)
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
        [ProducesResponseType(typeof(LeadDetailsModel), (int)HttpStatusCode.Created)]
        public ActionResult Post([FromBody] LeadCreateModel leadModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var leadDetailsModel = _leadService.Creation(leadModel);

            return CreatedAtAction(nameof(Post), leadDetailsModel);
        }

        // PUT: api/Leads/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] LeadSummaryModel leadNew)
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


        private LeadSummaryModel Find(int id)
        {
            return new LeadSummaryModel(); // _leadRepository.GetById(id);
        }
    }
}
