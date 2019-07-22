using Bogus;
using RedSpark.Thot.Api.Domain.Models.Leads;
using RedSpark.Thot.Api.Models.Lead.Output;
using System;
using System.Collections.Generic;

namespace RedSpark.Thot.Api.Infra.CrossCutting.Helpers
{
    public static class DataGenerator
    {
        public static List<LeadSummary> LeadSummaries(int amount)
        {
            return new Faker<LeadSummary>()
                .RuleFor(l => l.Id, f => f.IndexFaker)
                .RuleFor(l => l.Title, f => f.Lorem.Sentence(3))
                .RuleFor(l => l.CreatedBy, f => $"{f.Person.FirstName} {f.Person.LastName}")
                .RuleFor(l => l.IsFollowing, f => f.Random.Bool())
                .RuleFor(l => l.Status, f => f.Random.CollectionItem( new string[] { "COLD", "HOT" }))
                .RuleFor(l => l.FollowerAmount, f => f.Random.Number(10))
                .RuleFor(l => l.ComentAmount, f => f.Random.Number(20))
                .RuleFor(l => l.UpdateDate, f => f.Date.Between(DateTime.Now.AddDays(-7), DateTime.Now))
                .Generate(amount);
        }
    }
}
