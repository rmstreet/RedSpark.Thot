using RedSpark.Thot.Api.Domain.Interfaces.UnitOfWork;
using RedSpark.Thot.Api.Infra.Data.EF.Context;
using System;
using Microsoft.Extensions.DependencyInjection;
using RedSpark.Thot.Api.Domain.Core.Notifications;

namespace RedSpark.Thot.Api.Infra.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private ThotContext _context;
        private IServiceProvider _provider;
        private INotificationHandler _notificationHandler;

        public UnitOfWork(ThotContext context, IServiceProvider provider, INotificationHandler notificationHandler)
        {
            _context = context;
            _provider = provider;
            _notificationHandler = notificationHandler;
        }


        public TRepository GetRepository<TRepository>()
        {
            return _provider.GetService<TRepository>();
        }

        public bool Commit()
        {
            // TODO: Verificar se podemos salvar as alterações
            if (!_notificationHandler.HasNotification())
            {
                _context.SaveChanges();
                return true;
            }

            return false;            
        }
    }
}
