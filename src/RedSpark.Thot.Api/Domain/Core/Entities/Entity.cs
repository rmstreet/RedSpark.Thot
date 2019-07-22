using System;

namespace RedSpark.Thot.Api.Domain.Core.Entities
{
    public abstract class Entity
    {        

        protected Entity()
        {
            CreateDate = DateTime.UtcNow;
        }

        public int Id { get; protected set; }
        public DateTime? UpdateDate { get; protected set; }
        public DateTime CreateDate { get; private set; }
    }
}
