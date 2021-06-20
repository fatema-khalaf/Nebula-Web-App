using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Nebula.Enum;

namespace Nebula.Models
{
    public class Orders:BaseEntity<int>
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public string Email { get; set; }
        public int bookId { get; set; }
        [ForeignKey("bookId")]
        public Books books { get; set; }
       // public int? test { get; set; }


    }
}
