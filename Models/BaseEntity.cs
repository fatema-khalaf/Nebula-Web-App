using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nebula.Models
{
    public class BaseEntity <T>
    {
        //common entities between many tables!
        // T means that the Id can be "int or string or..." to be determined later 
        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
            IsDelete = false;
        }
        [Key]
        public T Id { get; set; }
        public bool IsDelete { get; set; }
        public DateTime LastModify { get; set; }
        public DateTime CreatedDate { get; set; }
        public String CreatedBy { get; set; }
    }
}
