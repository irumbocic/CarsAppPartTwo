using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.WebAPI.Dto
{
    public class VehicleModelDto
    {
        //[Required]
        public int Id { get; set; }
        [Required]
        public int MakeId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Abrv { get; set; }
        public virtual VehicleMakeDto VehicleMake { get; set; }
    }
}
