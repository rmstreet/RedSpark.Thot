﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RedSpark.Thot.Api.Infra.Data.EF.Context;

namespace RedSpark.Thot.Api.Infra.Data.EF.Migrations
{
    [DbContext(typeof(ThotContext))]
    [Migration("20190725001616_Create-Tables-And-Relationships-Thot")]
    partial class CreateTablesAndRelationshipsThot
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RedSpark.Thot.Api.Domain.Entities.Leads.Coment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<int>("CreatedById");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(500)");

                    b.Property<int?>("FatherComentId");

                    b.Property<int>("LeadId");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("FatherComentId");

                    b.HasIndex("LeadId");

                    b.ToTable("Coment");
                });

            modelBuilder.Entity("RedSpark.Thot.Api.Domain.Entities.Leads.Lead", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<int>("CreatedById");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(60)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.ToTable("Lead");
                });

            modelBuilder.Entity("RedSpark.Thot.Api.Domain.Entities.Persons.PersonLead", b =>
                {
                    b.Property<int>("LeadId");

                    b.Property<int>("PersonId");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime");

                    b.HasKey("LeadId", "PersonId");

                    b.HasIndex("PersonId");

                    b.ToTable("PersonLead");
                });

            modelBuilder.Entity("RedSpark.Thot.Api.Domain.Entities.Persons.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Password")
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Username")
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Person");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("RedSpark.Thot.Api.Domain.Entities.Projects.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BeginDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(1000)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime");

                    b.Property<string>("LogoUrl")
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("ResponsibleId");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("ResponsibleId");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("RedSpark.Thot.Api.Domain.Entities.Projects.ProjectPerson", b =>
                {
                    b.Property<int>("ProjectId");

                    b.Property<int>("PersonId");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<int>("Id");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime");

                    b.HasKey("ProjectId", "PersonId");

                    b.HasIndex("PersonId");

                    b.ToTable("ProjectPerson");
                });

            modelBuilder.Entity("RedSpark.Thot.Api.Domain.Entities.Skills.PersonSkill", b =>
                {
                    b.Property<int>("PersonId");

                    b.Property<int>("SkillId");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<int>("Id");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime");

                    b.HasKey("PersonId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("PersonSkill");
                });

            modelBuilder.Entity("RedSpark.Thot.Api.Domain.Entities.Skills.ProjectSkill", b =>
                {
                    b.Property<int>("ProjectId");

                    b.Property<int>("SkillId");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<int>("Id");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime");

                    b.HasKey("ProjectId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("ProjectSkill");
                });

            modelBuilder.Entity("RedSpark.Thot.Api.Domain.Entities.Skills.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("RedSpark.Thot.Api.Domain.Entities.Persons.Person", b =>
                {
                    b.HasBaseType("RedSpark.Thot.Api.Domain.Entities.Persons.User");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Job")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Phone")
                        .HasColumnType("varchar(11)");

                    b.Property<string>("Resume")
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("UrlGithub")
                        .HasColumnType("varchar(500)");

                    b.HasDiscriminator().HasValue("Person");
                });

            modelBuilder.Entity("RedSpark.Thot.Api.Domain.Entities.Leads.Coment", b =>
                {
                    b.HasOne("RedSpark.Thot.Api.Domain.Entities.Persons.Person", "CreatedBy")
                        .WithMany("ComentsByMe")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RedSpark.Thot.Api.Domain.Entities.Leads.Coment", "FatherComent")
                        .WithMany("Answers")
                        .HasForeignKey("FatherComentId");

                    b.HasOne("RedSpark.Thot.Api.Domain.Entities.Leads.Lead", "Lead")
                        .WithMany("Coments")
                        .HasForeignKey("LeadId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RedSpark.Thot.Api.Domain.Entities.Leads.Lead", b =>
                {
                    b.HasOne("RedSpark.Thot.Api.Domain.Entities.Persons.Person", "CreatedBy")
                        .WithMany("LeadsCreatedByMe")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("RedSpark.Thot.Api.Domain.Entities.Persons.PersonLead", b =>
                {
                    b.HasOne("RedSpark.Thot.Api.Domain.Entities.Leads.Lead", "Lead")
                        .WithMany("PersonsFollowing")
                        .HasForeignKey("LeadId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RedSpark.Thot.Api.Domain.Entities.Persons.Person", "Person")
                        .WithMany("LeadsFollowedByMe")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RedSpark.Thot.Api.Domain.Entities.Projects.Project", b =>
                {
                    b.HasOne("RedSpark.Thot.Api.Domain.Entities.Persons.Person", "Responsible")
                        .WithMany("ProjectsResponsible")
                        .HasForeignKey("ResponsibleId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("RedSpark.Thot.Api.Domain.Entities.Projects.ProjectPerson", b =>
                {
                    b.HasOne("RedSpark.Thot.Api.Domain.Entities.Persons.Person", "Person")
                        .WithMany("ProjectsMember")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RedSpark.Thot.Api.Domain.Entities.Projects.Project", "Project")
                        .WithMany("Members")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RedSpark.Thot.Api.Domain.Entities.Skills.PersonSkill", b =>
                {
                    b.HasOne("RedSpark.Thot.Api.Domain.Entities.Persons.Person", "Person")
                        .WithMany("MySkills")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RedSpark.Thot.Api.Domain.Entities.Skills.Skill", "Skill")
                        .WithMany("PersonSkill")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RedSpark.Thot.Api.Domain.Entities.Skills.ProjectSkill", b =>
                {
                    b.HasOne("RedSpark.Thot.Api.Domain.Entities.Projects.Project", "Project")
                        .WithMany("Skills")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RedSpark.Thot.Api.Domain.Entities.Skills.Skill", "Skill")
                        .WithMany("ProjectSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}