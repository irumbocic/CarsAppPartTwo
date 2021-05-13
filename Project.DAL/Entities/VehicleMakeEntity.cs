using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Project.DAL.Entities
{
    public class VehicleMakeEntity
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Abrv { get; set; }

        public virtual ICollection<VehicleModelEntity> VehicleModels { get; set; }
    }
}
