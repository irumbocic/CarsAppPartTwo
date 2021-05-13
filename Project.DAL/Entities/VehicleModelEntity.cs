using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Project.DAL.Entities
{
    public class VehicleModelEntity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("VehicleMake")]
        [Required]
        public int MakeId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Abrv { get; set; }


        public virtual VehicleMakeEntity VehicleMake { get; set; }
    }
}
