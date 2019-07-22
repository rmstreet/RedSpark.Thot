using RedSpark.Thot.Api.Domain.Core.Entities;
using RedSpark.Thot.Api.Domain.Entities.Projects;
using System.Collections.Generic;

namespace RedSpark.Thot.Api.Domain.Entities.Persons
{
    public class Skill : Entity
    {
        public Skill(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public List<Person> Persons { get; private set; }
        public List<Project> Projects { get; private set; }

    }
}
