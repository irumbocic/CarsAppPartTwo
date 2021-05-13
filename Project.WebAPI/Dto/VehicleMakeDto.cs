using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.WebAPI.Dto
{
    public class VehicleMakeDto
    {
        //[Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Abrv { get; set; }

        //public virtual ICollection<VehicleModelDto> VehicleModels { get; set; }
    }
}
