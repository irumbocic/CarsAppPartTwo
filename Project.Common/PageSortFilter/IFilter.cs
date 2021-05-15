using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Common
{
    public interface IFilter
    {
        public string SearchString { get; set; }
        public string SearchByField { get; set; }
    }
}
