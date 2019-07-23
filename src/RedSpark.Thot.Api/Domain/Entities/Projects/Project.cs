using RedSpark.Thot.Api.Domain.Core.Entities;
using RedSpark.Thot.Api.Domain.Entities.Persons;
using RedSpark.Thot.Api.Domain.Entities.Skills;
using System;
using System.Collections.Generic;

namespace RedSpark.Thot.Api.Domain.Entities.Projects
{
    public class Project : Entity
    {
        public Project(string logoUrl, string name, string company, 
            string description, DateTime beginDate, DateTime endDate,
            int responsibleId)
        {
            LogoUrl = logoUrl;
            Name = name;
            Company = company;
            Description = description;
            BeginDate = beginDate;
            EndDate = endDate;
            ResponsibleId = responsibleId;
        }

        public string LogoUrl { get; private set; }
        public string Name { get; private set; }
        public string Company { get; private set; }
        public string Description { get; private set; }
        public DateTime BeginDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public int ResponsibleId{ get; private set; }
        public Person Responsible { get; private set; }


        public List<ProjectSkill> Skills { get; private set; }
        public List<ProjectPerson> Members { get; private set; }
    }

}
