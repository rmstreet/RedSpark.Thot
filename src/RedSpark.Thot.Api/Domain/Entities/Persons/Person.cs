using RedSpark.Thot.Api.Domain.Core.ValueObject;
using RedSpark.Thot.Api.Domain.Entities.Projects;
using RedSpark.Thot.Api.Domain.Entities.Skills;
using RedSpark.Thot.Api.Domain.Entities.Leads;
using System.Collections.Generic;
using RedSpark.Thot.Api.Domain.Core.Entities;
using System;

namespace RedSpark.Thot.Api.Domain.Entities.Persons
{
    public class Person : Entity
    {
        public Person(string name, string job, string email)
        {
            Name = name;
            Job = job;
            Email = email;
            Active = false; 
            // Só será ativada quando o usuario fizer o login com o mesmo email associado.
        }

        public string ImageUrl { get; private set; }
        public string Name { get; private set; }
        public string Resume { get; private set; }
        public string Job { get; private set; }
        public string Email { get; private set; } // Poderia ser um ValueObject de Email, onde teria um tratamento para lidar com Email
        public Phone Phone { get; private set; }
        public string UrlGithub { get; private set; }
        public bool Active { get; private set; }

        public List<Lead> LeadsCreatedByMe { get; private set; }

        internal void Actived()
        {
            Active = true;
        }

        public List<PersonLead> LeadsFollowedByMe { get; private set; }
        public List<PersonSkill> MySkills { get; private set; }
        public List<Project> ProjectsResponsible { get; private set; }
        public List<Coment> ComentsByMe { get; private set; }
        public List<ProjectPerson> ProjectsMember { get; private set; }

        // Relacionamento 1 -> 1 com Usuario, mas uma pessoa pode existir sem ter usuário
        public int? UserId { get; private set; }
        public User User { get; private set; }

        /**
         * Criar Metodos para atualizar os campos Opicionais

         * */

    }

}
