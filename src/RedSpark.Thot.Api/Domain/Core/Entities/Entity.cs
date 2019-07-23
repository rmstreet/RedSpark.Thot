using System;

namespace RedSpark.Thot.Api.Domain.Core.Entities
{
    public abstract class Entity
    {        

        protected Entity()
        {
        }

        public int Id { get; protected set; }
        private DateTime? _updateDate;
        private DateTime _createDate;
        public DateTime? UpdateDate => _updateDate;
        public DateTime CreateDate => _createDate;
    }
}
