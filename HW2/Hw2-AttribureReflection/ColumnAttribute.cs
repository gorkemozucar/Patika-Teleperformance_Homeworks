using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw2_AttributeReflection
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnAttribute : Attribute
    {
        public string? Name { get; }
        public Type? Type { get; }
        public bool IsRequired { get; }

        public ColumnAttribute(string? name, Type? type, bool ısRequired)
        {
            Name = name;
            Type = type;
            IsRequired = ısRequired;
        }
    }
}
