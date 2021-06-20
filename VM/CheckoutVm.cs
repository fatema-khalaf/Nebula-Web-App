using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nebula.Enum;

namespace Nebula.VM
{
    public class CheckoutVm
    {
        public BooksVM book { get; set; }
        public int Id { get; set; }
        public int bookId { get; set; }
        public string  FullName { get; set; }
        public  string Address { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime CreatedDate { get; set; }
        public OrderStatus OrderStatus { get;  set; }
        public string  Email { get; set; }

    }
    

}
