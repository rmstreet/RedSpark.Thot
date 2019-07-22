
using RedSpark.Thot.Api.Domain.Core.Entities;
using RedSpark.Thot.Api.Domain.Models.Leads;
using System.Collections.Generic;
using System.Security;

namespace RedSpark.Thot.Api.Domain.Entities.Persons
{
    public class User : Entity
    {
        public User(string username, SecureString password)
        {
            Username = username;
            Password = password;
        }

        public string Username { get; set; }
        public SecureString Password { get; set; }
                
        public List<LeadComent> Coments { get; private set; }
    }
}
