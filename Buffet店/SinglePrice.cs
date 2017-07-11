using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buffet店
{
    public interface SinglePriceInterface
    {
        string Name { get; set; }
        int Count { get; set; }
        double Price { get; set; }
    }
}
