using RedSpark.Thot.Api.Domain.Core.ValueObject;
using RedSpark.Thot.Api.Domain.Entities.Projects;
using RedSpark.Thot.Api.Domain.Models.Leads;
using System.Collections.Generic;
using System.Security;

namespace RedSpark.Thot.Api.Domain.Entities.Persons
{
    public class Person : User
    {
        public Person(string imageUrl, string name, string resume, string job, Phone phone, string urlGithub, string username, SecureString password)
            : base(username, password)
        {
            ImageUrl = imageUrl;
            Name = name;
            Resume = resume;
            Job = job;
            Phone = phone;
            UrlGithub = urlGithub;
        }

        public string ImageUrl { get; private set; }
        public string Name { get; private set; }
        public string Resume { get; private set; }
        public string Job { get; private set; }
        public Phone Phone { get; private set; }
        public string UrlGithub { get; private set; }

        public List<Lead> LeadsResponsible { get; private set; }
        public List<Skill> Skills { get; private set; }
        public List<Project> Projects { get; private set; }
        public List<LeadComent> ComentsByMe { get; set; }

    }

}
