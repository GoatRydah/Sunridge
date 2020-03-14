using System;
using System.Collections.Generic;
using System.Text;

namespace Sunridge.DataAccess.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IApplicationUserRepository ApplicationUser { get; }
        IKeyRepository Key { get; }
        IKeyHistoryRepository KeyHistory { get; }
        ILotRepository Lot { get; }
        ILotHistoryRepository LotHistory { get; }
        ILotInventoryRepository LotInventory { get; }
        IMaintenanceRepository Maintenance { get; }
        INewsItemRepository NewsItem { get; }
        IPhotoRepository Photo { get; }
        IScheduledEventsRepository ScheduledEvents { get; }
        ITransactionRepository Transaction { get; }
        ITransactionTypeRepository TransactionType { get; }

        void Save();
    }
}
