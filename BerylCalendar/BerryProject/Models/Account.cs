using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BerryProject.Models
{
    public partial class Account
    {
        public Account()
        {
            Event = new HashSet<Event>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(31)]
        public string Username { get; set; }

        [InverseProperty("Account")]
        public virtual ICollection<Event> Event { get; set; }
    }
}
