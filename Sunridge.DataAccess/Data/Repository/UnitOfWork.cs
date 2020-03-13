using Sunridge.Data;
using Sunridge.DataAccess.Data.Repository.IRepository;

namespace Sunridge.DataAccess.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public IKeyRepository Key { get; private set; }
        public IKeyHistoryRepository KeyHistory { get; private set; }
        public ILotRepository Lot { get; private set; }
        public ILotHistoryRepository LotHistory { get; private set; }

        //Grabs a connection to the actual db to connect to this class
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Key = new KeyRepository(_db);
            KeyHistory = new KeyHistoryRepository(_db);
            Lot = new LotRepository(_db);
            LotHistory = new LotHistoryRepository(_db);
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
