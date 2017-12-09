using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IProduct : IEntity
    {
        string Code { get; set; }
        string Name { get; set; }
        decimal SalesRate { get; set; }
    }
}
