using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nebula.Models
{
    public class Brands:BaseEntity<int>
    {
        // Brand database table entities
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageId { get; set; }

    }
}
