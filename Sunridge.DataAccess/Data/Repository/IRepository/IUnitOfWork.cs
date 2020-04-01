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
        IBoardMemberRepository BoardMember { get; }
        IClassifiedCategoryRepository ClassifiedCategory { get; }
        IClassifiedListingRepository ClassifiedListing { get; }
        IClassifiedServiceRepository ClassifiedService { get; }
        IClassifiedListingVMRepository ClassifiedListingVM { get; }
        ICommentRepository Comment { get; }
        ICommonAreaAssetRepository CommonAreaAsset { get; }
        IErrorViewModelRepository ErrorViewModel { get; }
        IFileRepository File { get; }
        IFormResponseRepository FormResponse { get; }
        IInKindWorkHoursRepository InKindWorkHours { get; }
        IInventoryRepository Inventory { get; }
        IAdminPhotoViewModelsRepository AdminPhotoViewModels { get; }
        IClassifiedListingViewModelRepository ClassifiedListingViewModel { get; }
        IDashboardViewModelRepository DashboardViewModel { get; }
        ILostAndFoundItemRepository LostAndFoundItem { get; }
        IChatRoomRepository ChatRoomItem { get; }
        IKeyRepository Key { get; }
        IKeyHistoryRepository KeyHistory { get; }
        ILotRepository Lot { get; }
        ILotHistoryRepository LotHistory { get; }
        ILotInventoryRepository LotInventory { get; }
        IMaintenanceRepository Maintenance { get; }
        INewsItemRepository NewsItem { get; }
        IPhotoRepository Photo { get; }
        IPhotoCategoriesRepository PhotoCategories { get; }
        IScheduledEventsRepository ScheduledEvents { get; }
        ITransactionRepository Transaction { get; }
        ITransactionTypeRepository TransactionType { get; }

        void Save();
    }
}
