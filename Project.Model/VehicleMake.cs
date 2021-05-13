using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Project.Model
{
    public class VehicleMake
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Abrv { get; set; }

        public virtual ICollection<VehicleModel> VehicleModels { get; set; }
    }
}
