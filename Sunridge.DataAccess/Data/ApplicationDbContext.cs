using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SunridgeHOA.Models;

namespace Sunridge.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Key> Key { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<KeyHistory> KeyHistory { get; set; }
        public DbSet<Lot> Lot { get; set; }
        public DbSet<LotHistory> LotHistory { get; set; }
        public DbSet<LotInventory> LotInventory { get; set; }
        public DbSet<Maintenance> Maintenance { get; set; }
        public DbSet<NewsItem> NewsItem { get; set; }
        public DbSet<OwnerLot> OwnerLot { get; set; }
        public DbSet<Photo> Photo { get; set; }
        public DbSet<ScheduledEvent> ScheduledEvent { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<TransactionType> TransactionType { get; set; }
    }
}
