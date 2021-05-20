using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cinema.Models
{
    [Table("client")]
    public partial class Client
    {
        public Client()
        {
            Receipt = new HashSet<Receipt>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        [Required]
        [StringLength(200)]
        public string Lastname { get; set; }
        [StringLength(200)]
        public string Nit { get; set; }
        [Column(TypeName = "int(11)")]
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        [Column(TypeName = "bit(1)")]
        public short IsActive { get; set; }

        [InverseProperty("Client")]
        public virtual ICollection<Receipt> Receipt { get; set; }
    }
}
