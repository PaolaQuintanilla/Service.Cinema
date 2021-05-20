using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cinema.Models
{
    [Table("receipt")]
    public partial class Receipt
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int Id { get; set; }
        [Column("Client_Id", TypeName = "int(11)")]
        public int ClientId { get; set; }
        [Column("code")]
        [StringLength(45)]
        public string Code { get; set; }
        [Column("Ticket_Id", TypeName = "int(11)")]
        public int TicketId { get; set; }

        [ForeignKey(nameof(ClientId))]
        [InverseProperty("Receipt")]
        public virtual Client Client { get; set; }
        [ForeignKey(nameof(TicketId))]
        [InverseProperty("Receipt")]
        public virtual Ticket Ticket { get; set; }
    }
}
