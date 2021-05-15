using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Common
{
    public class Filter : IFilter
    {
        public string SearchString { get; set; }
        public string SearchByField { get; set; }
    }
}
