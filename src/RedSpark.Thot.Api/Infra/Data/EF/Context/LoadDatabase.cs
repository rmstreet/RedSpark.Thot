using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RedSpark.Thot.Api.Domain.Entities.Persons;
using System;
using System.Linq;

namespace RedSpark.Thot.Api.Infra.Data.EF.Context
{
    public static class LoadDatabase
    {
        public static void IncludeData(this IApplicationBuilder app)
        {
            IncludeDataDb(app.ApplicationServices.GetRequiredService<ThotContext>());
        }

        public static void IncludeDataDb(ThotContext context)
        {
            Console.WriteLine("Apply Migrations...");
            context.Database.Migrate();
            if (!context.Persons.Any())
            {
                Console.WriteLine("Create data...");
                context.Persons.AddRange(
                    new Person("Rômulo Martins", "Desenvolvedor", "romulo.martins@redspark.io"),
                    new Person("Bruno Fachine", "Desenvolvedor", "bruno.fachine@redspark.io"),
                    new Person("Augusto Junior", "Suporte", "augusto.junior@redspark.io"));

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Data already exists...");
            }
        }
    }
}
