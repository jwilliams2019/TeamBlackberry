using BerylCalendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using BerylCalendar.Utilities;
using BerylCalendar.Data;
using BerylCalendar.Data.Abstract;
using Microsoft.AspNetCore.Http;

namespace BerylCalendar.Data.Abstract
{
    public interface IEventRepository : IRepository<Event>
    {
        Task<List<Event>> GetEventsByDate(string filter, string userName, DateTime startDateOne, DateTime startDateTwo);

        Task<List<Event>> GetAllEvents(string filter, string userName);

        Task<List<Event>> GetEventsByType(string filter, string userName);
    }
}