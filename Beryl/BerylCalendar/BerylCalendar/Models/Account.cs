using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BerylCalendar.Models
{
    [Table("Account")]
    public partial class Account
    {
        public Account()
        {
            Events = new HashSet<Event>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(31)]
        public string Username { get; set; }

        [InverseProperty(nameof(Event.Account))]
        public virtual ICollection<Event> Events { get; set; }
    }
}
