using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BerylCalendar.Models
{
        public partial class CrudEvent
    {
        public Event eve { get; set; }
        public string typeId { get; set; }
        public string idString { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public int errorNum { get; set; }
        public string[] types { get; set; }
    }
}