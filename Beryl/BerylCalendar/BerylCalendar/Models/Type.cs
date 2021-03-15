using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BerylCalendar.Models
{
    [Table("Type")]
    public partial class Type
    {
        public Type()
        {
            Events = new HashSet<Event>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(15)]
        public string Name { get; set; }

        [InverseProperty(nameof(Event.Type))]
        public virtual ICollection<Event> Events { get; set; }
    }
}
