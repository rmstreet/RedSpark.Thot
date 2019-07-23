using RedSpark.Thot.Api.Domain.Core.Entities;
using RedSpark.Thot.Api.Domain.Entities.Projects;

namespace RedSpark.Thot.Api.Domain.Entities.Skills
{
    public class ProjectSkill : Entity
    {
        public int ProjectId { get; private set; }
        public Project Project { get; private set; }

        public int SkillId { get; private set; }
        public Skill Skill { get; private set; }
    }
}
