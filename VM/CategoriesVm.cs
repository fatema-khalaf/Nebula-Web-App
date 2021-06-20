using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nebula.Models;

namespace Nebula.VM
{
    public class CategoriesVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ImageId { get; set; }
        public int? ParentId { get; set; }
        public String Parent { get; set; }
        public List<string> Images { get; set; }
        public Categories ToEntity()
        {
            return new Categories()
            {
                Name = Name,
                Id = Id,
                Description = Description,
                ParentId = ParentId
            };
        }
    }
}
