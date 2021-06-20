using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nebula.Enum;
using Nebula.Models;

namespace Nebula.VM
{
    public class BooksVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Publisher { get; set; }
        public string pages { get; set; }
        public int Price { get; set; }
        public Language Language { get; set; }
        public int categoryId { get; set; }
        public Categories categories { get; set; }
        public int BrandId { get; set; }
        public Brands Brand { get; set; }
        public string ImageId { get; set; }
        public List<string> Images { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }

        public Books ToEntity()
        {
            return new Books
            {
                Name = Name,
                Description = Description,
                Publisher=Publisher,
                pages=pages,
                Brand= Brand,
                categories= categories,
                Price=Price,
                Language=Language,
                CategoryId=categoryId,
                BrandId=BrandId
            };         
        }

    }







}
