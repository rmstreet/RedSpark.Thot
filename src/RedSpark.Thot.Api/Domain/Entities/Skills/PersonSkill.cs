using RedSpark.Thot.Api.Domain.Core.Entities;
using RedSpark.Thot.Api.Domain.Entities.Persons;

namespace RedSpark.Thot.Api.Domain.Entities.Skills
{
    public class PersonSkill : Entity
    {
        public int PersonId { get; private set; }
        public Person Person { get; private set; }
        public int SkillId { get; private set; }
        public Skill Skill { get; private set; }        
    }
}
