using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Project.Model
{
    public class VehicleModel
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("VehicleMake")]
        [Required]
        public int MakeId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Abrv { get; set; }


        public virtual VehicleMake VehicleMake { get; set; }
    }
}
