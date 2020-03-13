﻿using System;
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
        public DbSet<KeyHistory> KeyHistory { get; set; }
        public DbSet<Lot> Lot { get; set; }
        public DbSet<LotHistory> LotHistory { get; set; }
    }
}
