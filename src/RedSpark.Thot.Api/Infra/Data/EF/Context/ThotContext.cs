using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RedSpark.Thot.Api.Domain.Core.Entities;
using RedSpark.Thot.Api.Domain.Entities.Leads;
using RedSpark.Thot.Api.Domain.Entities.Persons;
using RedSpark.Thot.Api.Domain.Entities.Projects;
using RedSpark.Thot.Api.Domain.Entities.Skills;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RedSpark.Thot.Api.Infra.Data.EF.Context
{
    public class ThotContext : DbContext
    {
        // LEADS
        public DbSet<Lead> Leads { get; set; }
        public DbSet<Coment> Coments { get; set; }

        // PERSONS
        public DbSet<User> Users { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<PersonLead> PersonLeads { get; set; }
        

        // PROJECTS
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectPerson> ProjectPersons { get; set; }

        // SKILL
        public DbSet<Skill> Skills { get; set; }
        public DbSet<PersonSkill> PersonSkills { get; set; }
        public DbSet<ProjectSkill> ProjectSkills { get; set; }



        public ThotContext(DbContextOptions<ThotContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            

            #region Mapeamento default para propriedades - Exemplo: Todas as Propriedades String como varchar
            // Apartir do EF Core v1.1.0
            //modelBuilder
            //    .Model   // 1 - Pegando Modelo de Configuração
            //    .GetEntityTypes()  // 2 - Todos os tipos de entidades, vulgo o que é mapeado para virar tabela
            //    .SelectMany(t => t.GetProperties())  // 3 - Pegar todas as propriedades de todas as entidades
            //    .Where(p => p.ClrType == typeof(string))  // 4 - Filtrando apenas entidade do tipo string
            //    .Select(p => modelBuilder.Entity(p.DeclaringEntityType.ClrType).Property(p.Name))  // 5 - Selecionando e Mapeando as Propriedades
            //    .Select(pb => pb
            //                .HasColumnType("varchar")   // 6 - Determinando que as coluans no banco sejam varchar
            //                .HasMaxLength(100)          // 7 - Tamanho Padrão será de 100 caracteres
            //            )
            //    .ToList();  // 8 - Forçando o meu Lambda rodar

            //modelBuilder.Model.GetEntityTypes()
            //    .SelectMany(t => t.GetProperties())
            //    .Where(p => p.Name.Equals("CreateDate") || p.Name.Equals("UpdateDate"))
            //    .Select(p => modelBuilder
            //                    .Entity(p.DeclaringEntityType.ClrType)
            //                        .Property(p.Name)
            //                        .HasColumnType("datetime"))
            //    .ToList();

            #endregion


            #region Configurando Modelos - Opção 1

            //modelBuilder.Entity<Lead>()
            //    .ToTable("Lead");

            //modelBuilder.Entity<Lead>()
            //    .HasKey(l => l.Id);

            //modelBuilder.Entity<Lead>()
            //    .Property(l => l.Title)
            //    .HasColumnName("Titulo")
            //    .HasColumnType("varchar")
            //    .HasMaxLength(60)
            //    .IsRequired();

            #region Trabalhando com Conversões de valores para o banco
            //  Referencia: https://docs.microsoft.com/pt-br/ef/core/modeling/value-conversions
            #region Enum - Opção 1

            //modelBuilder.Entity<Lead>()
            //    .Property(l => l.Status)
            //    .HasConversion(
            //    s => s.ToString(),
            //    s => (LeadStatus)Enum.Parse(typeof(LeadStatus), s));

            #endregion

            #region Enum - Opção 2

            //var converter = new ValueConverter<LeadStatus, string>(
            //    v => v.ToString(),
            //    v => (LeadStatus)Enum.Parse(typeof(LeadStatus), v));

            //modelBuilder.Entity<LeadSummary>()
            //    .Property(l => l.Status)
            //    .HasConversion(converter);

            #endregion

            #region Enum - Opção 3

            //modelBuilder.Entity<Lead>()
            //    .Property(l => l.Status)
            //    .HasConversion(new EnumToStringConverter<LeadStatus>());


            #region Bool - Opção 1

            //modelBuilder.Entity<Lead>()
            //    .Property(l => l.IsSomething)
            //    .HasConversion(new BoolToTwoValuesConverter<string>("NAO", "SIM"));

            #endregion
            #endregion

            #region Enum - Opção 4

            /*      Para conversões comuns para o qual exista um conversor de interno não é necessário 
             *  especificar explicitamente o conversor. 
             *  Em vez disso, configure qual tipo de provedor deve ser usado e o EF usará automaticamente 
             *  o conversor interno apropriado.             *  
             * */

            //modelBuilder.Entity<Lead>()
            //   .Property(l => l.Status)
            //   .HasConversion<string>();

            #endregion

            #endregion
            #endregion

            #region Configurando Modelos - Opção 2
            // modelBuilder.ApplyConfiguration(new LeadMapConfig());
            ///...
            #endregion

            #region Configurando Modelos - Opção 3 (Nova)

            var assembly = typeof(ThotContext).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            #endregion

            #region Atribuir logicas de criação e atualização default - Part 1 - Opção 2
            /* TODO:
             *      Transformar as propriedade em readonly.
             * */

            //modelBuilder.Entity<Lead>()
            //    .Property(l => l.CreateDate)
            //    .HasField("_createDate"); // Nome da variavel privada.

            //modelBuilder.Entity<Lead>()
            //    .Property(l => l.UpdateDate)
            //    .HasField("_updateDate");


            #endregion

            #region Atribuir logicas de criação e atualização default - Part 1 - Opção 3
            /* TODO:
             *      Nesse caso não precisamos ter as propriedades.
             * */

            //modelBuilder.Entity<Lead>().Property<DateTime>("CreateDate");

            //modelBuilder.Entity<Lead>().Property("UpdateDate");


            #endregion

            base.OnModelCreating(modelBuilder);
        }


        #region Atribuir logicas de criação e atualização default - Part 2 - Opção 1, 2 e 3

        public override int SaveChanges()
        {
            OnBeforeSaving();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(cancellationToken);
        }

        #region Opção 1
        //private void OnBeforeSaving()
        //{
        //    /* TODO: 
        //    *      Os setters das propriedades precisam estar publicos
        //    *      ou implementar adhoc setter na classe Entity para atribuir a data.
        //    * */
        //    var entries = ChangeTracker.Entries();
        //    foreach (var entry in entries)
        //    {
        //        if (entry.Entity is Entity trackable)
        //        {
        //            var now = DateTime.UtcNow;
        //            switch (entry.State)
        //            {
        //                case EntityState.Modified:
        //                    trackable.UpdateDate = now;
        //                    break;

        //                case EntityState.Added:
        //                    trackable.CreateDate = now;
        //                    break;
        //            }
        //        }
        //    }
        //}
        #endregion

        #region Opção 2 e 3

        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                if (entry.Entity is Entity entityModel)
                {
                    var now = DateTime.UtcNow;
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            entry.CurrentValues["UpdateDate"] = now;
                            break;

                        case EntityState.Added:
                            entry.CurrentValues["CreateDate"] = now;
                            break;
                    }
                }
            }
        }
        #endregion

        #endregion


    }
}
