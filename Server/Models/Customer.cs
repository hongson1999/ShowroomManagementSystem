using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(70)]
        public string Name { get; set; }

        [Required]
        [StringLength(70)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(12)]
        public string Phone { get; set; }

        [Required]
        [StringLength(200)]
        public string Address { get; set; }
    }
}
