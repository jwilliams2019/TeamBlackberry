using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BerylCalendar.Models
{
    [Table("Event")]
    public partial class Event
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("TypeID")]
        public int TypeId { get; set; }
        [Column("AccountID")]
        public int AccountId { get; set; }
        [Required]
        [StringLength(63)]
        public string Title { get; set; }
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime StartDateTime { get; set; }
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime EndDateTime { get; set; }
        [StringLength(127)]
        public string Location { get; set; }
        [StringLength(255)]
        public string Details { get; set; }

        [ForeignKey(nameof(AccountId))]
        [InverseProperty("Events")]
        public virtual Account Account { get; set; }
        [ForeignKey(nameof(TypeId))]
        [InverseProperty("Events")]
        public virtual Type Type { get; set; }
    }
}
