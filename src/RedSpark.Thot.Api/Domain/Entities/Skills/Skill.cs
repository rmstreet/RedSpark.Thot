using RedSpark.Thot.Api.Domain.Core.Entities;
using System.Collections.Generic;

namespace RedSpark.Thot.Api.Domain.Entities.Skills
{
    public class Skill : Entity
    {
        public Skill(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public List<PersonSkill> PersonSkill { get; private set; }
        public List<ProjectSkill> ProjectSkills { get; private set; }
    }
}
