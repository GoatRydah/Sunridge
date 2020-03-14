using Microsoft.AspNetCore.Mvc.Rendering;
using SunridgeHOA.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sunridge.DataAccess.Data.Repository.IRepository
{
    public interface IScheduledEventsRepository : IRepository<ScheduledEvent>
    {
        IEnumerable<SelectListItem> GetScheduledEventsListOrDropdown();

        void Update(ScheduledEvent scheduledEvents);
    }
}
