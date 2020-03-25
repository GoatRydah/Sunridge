using Microsoft.AspNetCore.Mvc.Rendering;
using Sunridge.Data;
using Sunridge.DataAccess.Data.Repository.IRepository;
using Sunridge.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sunridge.DataAccess.Data.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDbContext _db;

        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetApplicationUserListOrDropdown()
        {
            return _db.ApplicationUser.Select(i => new SelectListItem()
            {
                Value = i.Id.ToString(),
                Text = i.FullName
            });
        }

        public int AddAddressAndGetId(ApplicationUser applicationUser)
        {
            Address addr = new Address();
            addr.Apartment = applicationUser.ApartmentValue;
            addr.City = applicationUser.CityValue;
            addr.State = applicationUser.StateValue;
            addr.StreetAddress = applicationUser.AddressValue;
            addr.Zip = applicationUser.ZipValue;

            _db.Address.Add(addr);

            _db.SaveChanges();

            int addrId;

            try
            {
                addrId = _db.Address.Select(s => s.Id).Max();
            }
            catch(Exception e)
            {
                var pants = e;
                addrId = 0;
            }

            return addrId;
        }

        public void Update(ApplicationUser applicationUser)
        {
            var objFromDb = _db.ApplicationUser.FirstOrDefault(s => s.Id == applicationUser.Id);
            objFromDb.FirstName = applicationUser.FirstName;
            objFromDb.LastName = applicationUser.LastName;
            objFromDb.OwnerLots = applicationUser.OwnerLots;
            objFromDb.AddressId = applicationUser.AddressId;
            objFromDb.Address = applicationUser.Address;
            objFromDb.Occupation = applicationUser.Occupation;
            objFromDb.Birthday = applicationUser.Birthday;
            objFromDb.Phone = applicationUser.Phone;
            objFromDb.Email = applicationUser.Email;
            objFromDb.EmergencyContactName = applicationUser.EmergencyContactName;
            objFromDb.EmergencyContactPhone = applicationUser.EmergencyContactPhone;
            objFromDb.ReceiveEmails = applicationUser.ReceiveEmails;
            objFromDb.IsArchive = applicationUser.IsArchive;
            objFromDb.LastModifiedBy = applicationUser.LastModifiedBy;
            objFromDb.LastModifiedDate = applicationUser.LastModifiedDate;
            objFromDb.Address = applicationUser.Address;
            objFromDb.Transactions = applicationUser.Transactions;
            objFromDb.FormResponses = applicationUser.FormResponses;
            objFromDb.ClassifiedListings = applicationUser.ClassifiedListings;
            objFromDb.KeyHistories = applicationUser.KeyHistories;
            objFromDb.LostAndFoundItems = applicationUser.LostAndFoundItems;

            _db.SaveChanges();
        }
    }
}
