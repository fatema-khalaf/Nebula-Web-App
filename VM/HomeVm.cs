using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nebula.VM
{
    public class HomeVm
    {
        public CheckoutVm checkout { get; set; }
        public List<CheckoutVm> chekout { get; set; }
        public List<BooksVM> ListCollection { get; set; }
        public List<BrandsVm> ListAuthor { get; set; }
        public List<CategoriesVm> listcategory { get; set; }
        public List<CategoriesVm> listsubcategory { get; set; }
        public List<BooksVM> ListBooks { get; set; }
    }
}
