using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cinema.Models
{
    [Table("movie")]
    public partial class Movie
    {
        public Movie()
        {
            Ticket = new HashSet<Ticket>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int Id { get; set; }
        [Required]
        [StringLength(1000)]
        public string Name { get; set; }
        public double Duration { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
        [Column(TypeName = "int(11)")]
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        [Column(TypeName = "bit(1)")]
        public short IsActive { get; set; }

        [InverseProperty("Movie")]
        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}
