using System.Collections.Generic;

namespace Pips.Models
{
    public class PipsResponse
    {
        public string Request { get; set; }

        public IEnumerable<int> Rolls { get; set; }
    }
}
