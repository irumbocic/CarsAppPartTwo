using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Common
{
    public class Sort : ISort // Trebam li uopce imati ovaj interface? Isto i za Filter
    {
        public string SortOrder { get; set; }
        public string OrderBy { get; set; }
    }
}
