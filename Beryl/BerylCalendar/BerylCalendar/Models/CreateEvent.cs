using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BerylCalendar.Models
{
        public partial class CreateEvent
    {
        public Event eve { get; set; }
        public bool authorized { get; set; }
        public string name { get; set; }
    }
}