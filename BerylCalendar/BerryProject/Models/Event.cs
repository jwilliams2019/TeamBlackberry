using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BerryProject.Models
{
    public partial class Event
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("TypeID")]
        public int TypeId { get; set; }
        [Column("AccountID")]
        public int AccountId { get; set; }
        [StringLength(63)]
        public string Title { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime StartTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime EndTime { get; set; }
        [StringLength(127)]
        public string Location { get; set; }

        [ForeignKey(nameof(AccountId))]
        [InverseProperty("Event")]
        public virtual Account Account { get; set; }
        [ForeignKey(nameof(TypeId))]
        [InverseProperty("Event")]
        public virtual Type Type { get; set; }
    }
}
