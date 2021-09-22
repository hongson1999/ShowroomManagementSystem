using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class ShowroomVehicle
    {
        [Key]
        [StringLength(20)]
        public string Id { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10, 2)")]
        public float SalePrice { get; set; }

        // -------------------
        [Required]
        [ForeignKey("Vehicle")]
        public int VehicleId { get; set; }

        public Vehicle Vehicle { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }

        public ICollection<WarehouseVehicle> WarehouseVehicles { get; set; }
    }
}
