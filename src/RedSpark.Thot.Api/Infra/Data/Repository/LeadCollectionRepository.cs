using RedSpark.Thot.Api.Domain.Interfaces;
using RedSpark.Thot.Api.Models.Lead.Output;
using System.Collections.Generic;
using System.Linq;

namespace RedSpark.Thot.Api.Data.Repository
{
    public class LeadCollectionRepository : ILeadRepository
    {
        public LeadCollectionRepository(ICollection<LeadSummary> leads)
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
                //lead.Update(leadNew);
                updated = true;
            }

            return updated;
        }
    }
}
