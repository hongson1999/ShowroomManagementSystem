using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int? Quantity { get; set; }

        // -------------------

        [Required]
        [ForeignKey("Order")]
        public int OrderId { get; set; }

        public Order Order { get; set; }

        // Nullable
        [ForeignKey("ShowroomVehicle")]
        public string ShowroomVehicleId { get; set; }

        public ShowroomVehicle ShowroomVehicle { get; set; }

        // Nullable
        [ForeignKey("Service")]
        public int? ServiceId { get; set; }

        public Service Service { get; set; }

        public ICollection<WarehouseVehicle> WarehouseVehicles { get; set; }
    }
}
