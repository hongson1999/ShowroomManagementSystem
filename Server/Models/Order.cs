using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public float Total { get; set; }

        [Required]
        [StringLength(200)]
        public string Address { get; set; }

        // 0: Purchase, 1: Sale
        [Required]
        public bool OrderForm { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime UpdatedAt { get; set; }

        // ----------------

        [Required]
        [ForeignKey("Dealer")]
        public int DealerId { get; set; }

        public Dealer Dealer { get; set; }

        [Required]
        [ForeignKey("Status")]
        public int StatusId { get; set; }

        public StatusOrder StatusOrder { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
    }
}
