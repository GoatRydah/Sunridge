﻿using Sunridge.Data;
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
        public ILotInventoryRepository LotInventory { get; private set; }
        public IMaintenanceRepository Maintenance { get; private set; }
        public INewsItemRepository NewsItem { get; private set; }
        public IPhotoRepository Photo { get; private set; }
        public IScheduledEventsRepository ScheduledEvents { get; private set; }
        public ITransactionRepository Transaction { get; private set; }
        public ITransactionTypeRepository TransactionType { get; private set; }

        //Grabs a connection to the actual db to connect to this class
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Key = new KeyRepository(_db);
            KeyHistory = new KeyHistoryRepository(_db);
            Lot = new LotRepository(_db);
            LotHistory = new LotHistoryRepository(_db);
            LotInventory = new LotInventoryRepository(_db);
            Maintenance = new MaintenanceRepository(_db);
            NewsItem = new NewsItemRepository(_db);
            Photo = new PhotoRepository(_db);
            ScheduledEvents = new ScheduledEventsRepository(_db);
            Transaction = new TransactionRepository(_db);
            TransactionType = new TransactionTypeRepository(_db);
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
