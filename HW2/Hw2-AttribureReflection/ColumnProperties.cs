using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw2_AttributeReflection
{
    public class ColumnProperties
    {
        public string? Name { get; set; }
        public Type? Type { get; set; }
        public bool? IsRequired { get; set; }
    }
}
