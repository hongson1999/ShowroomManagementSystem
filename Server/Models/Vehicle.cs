using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string ModelNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10, 2)")]
        public float Price { get; set; }

        /// ----------------------

        [Required]
        [ForeignKey("Branchs")]
        public int BranchId { get; set; }

        public Branch Branch { get; set; }

        public ShowroomVehicle ShowroomVehicles { get; set; }

        public ICollection<WarehouseVehicle> WarehouseVehicles { get; set; }
    }
}
