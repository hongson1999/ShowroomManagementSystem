using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class WarehouseVehicle
    {
        [Key]
        [StringLength(20)]
        public string Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime AllotDate { get; set; } = DateTime.Now.Date;

        // --------------

        [ForeignKey("OrderDetail")]
        public int? OrderDetailId { get; set; }

        public OrderDetail OrderDetail { get; set; }

        [Required]
        [ForeignKey("Vehicle")]
        public int VehicleId { get; set; }

        public Vehicle Vehicle { get; set; }

        [Required]
        [ForeignKey("ShowroomVehicle")]
        public string ShowroomVehicleId { get; set; }

        public ShowroomVehicle ShowroomVehicle { get; set; }
    }
}
