using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cinema.Models
{
    [Table("seat")]
    public partial class Seat
    {
        public Seat()
        {
            Ticket = new HashSet<Ticket>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int Id { get; set; }
        [Column(TypeName = "int(11)")]
        public int Number { get; set; }
        [Column(TypeName = "bit(1)")]
        public short Sold { get; set; }
        [Required]
        [StringLength(45)]
        public string Name { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
        [Column(TypeName = "int(11)")]
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        [Column(TypeName = "bit(1)")]
        public short IsActive { get; set; }
        [Column("Theater_Id", TypeName = "int(11)")]
        public int TheaterId { get; set; }

        [ForeignKey(nameof(TheaterId))]
        [InverseProperty("Seat")]
        public virtual Theater Theater { get; set; }
        [InverseProperty("Seat")]
        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}
