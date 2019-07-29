using Microsoft.EntityFrameworkCore;
using RedSpark.Thot.Api.Domain.Entities.Persons;
using RedSpark.Thot.Api.Domain.Interfaces.Repositories;

namespace RedSpark.Thot.Api.Infra.Data.Repository
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(DbSet<Person> dbSet) 
            : base(dbSet)
        {
        }
    }
}
