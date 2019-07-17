using RedSpark.Thot.Api.Interfaces;
using RedSpark.Thot.Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace RedSpark.Thot.Api.Repository
{
    public class LeadRepository : ILeadRepository
    {
        public LeadRepository(ICollection<LeadSummary> leads)
        {
            Leads = leads;
        }

        private ICollection<LeadSummary> Leads { get; }

        public void Create(LeadSummary leadSummary)
        {
            leadSummary.Id = Leads.Count + 1;
            Leads.Add(leadSummary);
        }

        public void Delete(LeadSummary leadSummary)
        {
            Leads.Remove(leadSummary);
        }

        public IEnumerable<LeadSummary> GetAll(bool? isFollowing = true)
        {
            return Leads;
        }

        public LeadSummary GetById(int id)
        {
            return Leads.SingleOrDefault(l => l.Id.Equals(id));
        }

        public bool Update(int id, LeadSummary leadNew)
        {
            var updated = false;
            var lead = GetById(id);

            if(lead != null)
            {
                lead.Update(leadNew);
                updated = true;
            }

            return updated;
        }
    }
}
