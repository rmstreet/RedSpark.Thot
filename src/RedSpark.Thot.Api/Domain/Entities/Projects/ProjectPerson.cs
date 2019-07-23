using RedSpark.Thot.Api.Domain.Core.Entities;
using RedSpark.Thot.Api.Domain.Entities.Persons;

namespace RedSpark.Thot.Api.Domain.Entities.Projects
{
    public class ProjectPerson : Entity
    {
        public ProjectPerson(int projectId, int personId)
        {
            ProjectId = projectId;
            PersonId = personId;
        }

        public int ProjectId { get; private set; }
        public Project Project { get; private set; }
        public int PersonId { get; private set; }
        public Person Person { get; private set; }
    }

}
