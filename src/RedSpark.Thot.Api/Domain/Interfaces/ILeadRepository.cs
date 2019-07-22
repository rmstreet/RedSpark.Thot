using RedSpark.Thot.Api.Models.Lead.Output;
using System.Collections.Generic;

namespace RedSpark.Thot.Api.Domain.Interfaces
{
    public interface ILeadRepository
    {
        void Create(LeadSummary leadSummary);
        LeadSummary GetById(int id);
        IEnumerable<LeadSummary> GetAll(bool? isFollowing = true);
        bool Update(int id, LeadSummary leadSummary);
        void Delete(LeadSummary leadSummary);
    }
}
