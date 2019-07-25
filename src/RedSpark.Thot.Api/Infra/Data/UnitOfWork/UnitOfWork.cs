using RedSpark.Thot.Api.Domain.Interfaces.UnitOfWork;
using RedSpark.Thot.Api.Infra.Data.EF.Context;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace RedSpark.Thot.Api.Infra.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private ThotContext _context;
        private IServiceProvider _provider;

        public UnitOfWork(ThotContext context, IServiceProvider provider)
        {
            _context = context;
            _provider = provider;
        }


        public TRepository GetRepository<TRepository>()
        {
            return _provider.GetService<TRepository>();
        }

        public bool Commit()
        {
            // TODO: Verificar se podemos salvar as alterações
            _context.SaveChanges();
            return true;
        }
    }
}
