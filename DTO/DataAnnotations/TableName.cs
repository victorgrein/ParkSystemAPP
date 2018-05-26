using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TableName : Attribute
    {
        public TableName(string name)
        {
            this.Name = name;
        }
        public string Name { get; private set; }
    }
}
