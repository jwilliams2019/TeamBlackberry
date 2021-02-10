using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BerryProject.Models
{
    public partial class Type
    {
        public Type()
        {
            Event = new HashSet<Event>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(15)]
        public string Name { get; set; }

        [InverseProperty("Type")]
        public virtual ICollection<Event> Event { get; set; }
    }
}
