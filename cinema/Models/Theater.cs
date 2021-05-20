using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cinema.Models
{
    [Table("theater")]
    public partial class Theater
    {
        public Theater()
        {
            Seat = new HashSet<Seat>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
        [Column(TypeName = "bit(1)")]
        public short IsActive { get; set; }
        [Column(TypeName = "int(11)")]
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }

        [InverseProperty("Theater")]
        public virtual ICollection<Seat> Seat { get; set; }
    }
}
