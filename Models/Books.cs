using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Nebula.Enum;

namespace Nebula.Models
{
    public class Books: BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Publisher { get; set; }
        public string pages { get; set; }
        public int Price { get; set; }
        public Language Language { get; set; }
        
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Categories categories { get; set; }
        
        public int BrandId { get; set; }
        [ForeignKey("BrandId")]
        public Brands Brand { get; set; }

    }
}
