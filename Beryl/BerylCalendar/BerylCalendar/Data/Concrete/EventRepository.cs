using BerylCalendar.Data.Abstract;
using BerylCalendar.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using BerylCalendar.Utilities;
using BerylCalendar.Data;
using Microsoft.AspNetCore.Http;

namespace BerylCalendar.Data.Concrete
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        public EventRepository(BerylDbContext ctx) : base(ctx)
        {

        }

        public virtual Task<List<Event>> GetEventsByDate(string filter, string userName, DateTime startDateOne, DateTime startDateTwo)
        {
            var test = _dbSet.Include(x => x.Account).Where(e => e.Account.Username == userName).Where(a => a.StartDateTime >= startDateOne && a.StartDateTime <= startDateTwo).OrderBy(y => y.StartDateTime).ToListAsync();
            return test;
        }

        public virtual Task<List<Event>> GetAllEvents(string filter, string userName)
        {
            var test = _dbSet.Include(x => x.Account).Where(e => e.Account.Username == userName).OrderBy(y => y.StartDateTime).ToListAsync();
            return test;
        }

        public virtual Task<List<Event>> GetEventsByType(string filter, string userName)
        {
            var test = _dbSet.Include(x => x.Account).Where(e => e.Account.Username == userName).Where(a => a.Type.Name.Contains(filter)).OrderBy(y => y.StartDateTime).ToListAsync();
            return test;
        }
    }
}