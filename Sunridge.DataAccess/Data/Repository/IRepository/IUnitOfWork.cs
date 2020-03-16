using System;
using System.Collections.Generic;
using System.Text;

namespace Sunridge.DataAccess.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IApplicationUserRepository ApplicationUser { get; }
        IAddressRepository Address { get; }
        IBannerRepository Banner { get; }
        IClassifiedCategoryRepository ClassifiedCategory { get; }
        IClassifiedImageRepository ClassifiedImage { get; }
        IClassifiedListingRepository ClassifiedListing { get; }
        ICommentRepository Comment { get; }
        ICommonAreaAssetRepository CommonAreaAsset { get; }
        IDbItemRepository DbItem { get; }
        IErrorViewModelRepository ErrorViewModel { get; }
        IFileRepository File { get; }
        IFormResponseRepository FormResponse { get; }
        IInKindWorkHoursRepository InKindWorkHours { get; }
        IInventoryRepository Inventory { get; }
        IAdminPhotoViewModelsRepository AdminPhotoViewModels { get; }
        IClassifiedListingViewModelRepository ClassifiedListingViewModel { get; }
        IDashboardViewModelRepository DashboardViewModel { get; }


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
