using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nebula.Data;
using Nebula.Enum;
using Nebula.Models;
using Nebula.VM;

namespace Nebula.Controllers
{
    public class UserController : Controller
    {
        private NebulaContext _nebulaContext;
        public UserController(NebulaContext nebulaContext)
        {
            _nebulaContext = nebulaContext;
        }
        //public async Task<IActionResult> Detail(int id)
        //{

        //    var bookDb = await _nebulaContext.Books.Include(x => x.Brand).Include(x => x.categories).FirstOrDefaultAsync(x => x.Id == id);
        //    var BooksVM = new BooksVM()
        //    {
        //        Id = bookDb.Id,
        //        Name = bookDb.Name,
        //        Description = bookDb.Description,
        //        pages = bookDb.pages,
        //        Price = bookDb.Price,
        //        Publisher = bookDb.Publisher,
        //        Brand = bookDb.Brand,
        //        Images = _nebulaContext.Attachments.Where(a => a.RecordId == bookDb.Id.ToString() && a.RecordType == Enum.RecordType.Books).Select(x => x.FileName).ToList()
        //    };
        //    return View(BooksVM);
        //}

        public IActionResult Index()
        {
            var listcollection = _nebulaContext.Books.Where(x=> x.IsDelete == false).Take(3).Select(x => new BooksVM()
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                ImageId = _nebulaContext.Attachments.FirstOrDefault(r => r.RecordId == x.Id.ToString() && r.RecordType == Enum.RecordType.Books).FileName
            }).ToList();
            var listBooks = _nebulaContext.Books.Where(x => x.IsDelete == false).Select(x => new BooksVM()
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                ImageId = _nebulaContext.Attachments.FirstOrDefault(r => r.RecordId == x.Id.ToString() && r.RecordType == Enum.RecordType.Books).FileName
            }).ToList();
            var ListAuthor = _nebulaContext.Brands.Where(x => x.IsDelete == false).Take(4).Select(x => new BrandsVm()
            {
                Id = x.Id,
                Name = x.Name,
                ImageId = x.ImageId,
            }).ToList();

            var listcategory = _nebulaContext.Categories.Where(x => x.IsDelete == false && x.ParentId == null).Select(x => new CategoriesVm()
            {
                Id = x.Id,
                Name = x.Name,              
                ImageId = _nebulaContext.Attachments.FirstOrDefault(r => r.RecordId == x.Id.ToString() && r.RecordType == Enum.RecordType.Categories).FileName
            }).ToList();
            
            var listsubcategory = _nebulaContext.Categories.Where(x => x.IsDelete == false && x.ParentId != null).Select(x => new CategoriesVm()
            {
                Id = x.Id,
                Name = x.Name,
                ParentId=x.ParentId,
                ImageId = _nebulaContext.Attachments.FirstOrDefault(r => r.RecordId == x.Id.ToString() && r.RecordType == Enum.RecordType.Categories).FileName
            }).ToList();

            return View(new HomeVm() { ListCollection =listcollection,ListBooks=listBooks, listcategory=listcategory, listsubcategory = listsubcategory, ListAuthor= ListAuthor });
        }
        public IActionResult Grid()
        {
            var listBooks = _nebulaContext.Books.Where(x => x.IsDelete == false).Select(x => new BooksVM()
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                ImageId = _nebulaContext.Attachments.FirstOrDefault(r => r.RecordId == x.Id.ToString() && r.RecordType == Enum.RecordType.Books).FileName
            }).ToList();
            return View(new HomeVm() { ListBooks = listBooks } );
            
        }
        public IActionResult AuthorGrid()
        {
            var ListAuthor = _nebulaContext.Brands.Where(x => x.IsDelete == false).Take(4).Select(x => new BrandsVm()
            {
                Id = x.Id,
                Name = x.Name,
                Description=x.Description,
                ImageId = x.ImageId,
            }).ToList();
            return View(new HomeVm() { ListAuthor = ListAuthor });

        }

        public IActionResult CategoriesGrid()
        {
            var listcategory = _nebulaContext.Categories.Where(x => x.IsDelete == false).Select(x => new CategoriesVm()
            {
                Id = x.Id,
                Name = x.Name,
                Description=x.Description,
                ImageId = _nebulaContext.Attachments.FirstOrDefault(r => r.RecordId == x.Id.ToString() && r.RecordType == Enum.RecordType.Categories).FileName
            }).ToList();
            return View(new HomeVm() { listcategory = listcategory });

        }
        public async Task<IActionResult> BooksCatGrid(int id)
        {
            var listBooks = _nebulaContext.Books.Where(x => x.IsDelete == false && x.CategoryId == id).Select(x => new BooksVM()
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                pages = x.pages,
                Publisher = x.Publisher,
                Brand = x.Brand,
                Description = x.Description,
                Images = _nebulaContext.Attachments.Where(a => a.RecordId == x.Id.ToString() && a.RecordType == Enum.RecordType.Books).Select(x => x.FileName).ToList(),
                ImageId = _nebulaContext.Attachments.FirstOrDefault(r => r.RecordId == x.Id.ToString() && r.RecordType == Enum.RecordType.Books).FileName
            }).ToList();

            return View(new HomeVm() { ListBooks = listBooks });
        }
        public async Task<IActionResult> Test(int id)
        {
            var listBooks = _nebulaContext.Books.Where(x => x.IsDelete == false && x.Id == id).Select(x => new BooksVM()
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                pages = x.pages,
                Publisher = x.Publisher,
                Brand = x.Brand,
                Description=x.Description,
                Images = _nebulaContext.Attachments.Where(a => a.RecordId == x.Id.ToString() && a.RecordType == Enum.RecordType.Books).Select(x => x.FileName).ToList(),
                ImageId = _nebulaContext.Attachments.FirstOrDefault(r => r.RecordId == x.Id.ToString() && r.RecordType == Enum.RecordType.Books).FileName
            }).ToList();

            return View(new HomeVm() { ListBooks = listBooks });
        }
        public async Task<IActionResult> Checkout(int id)
        {
   
            var checkoutVm = new CheckoutVm()
            {
                bookId = id
            };
            return View(new HomeVm() { checkout = checkoutVm });
        }

        //public async Task<IActionResult> Checkout(int id)
        //{
        //    var bookDb = await _nebulaContext.Books.Include(x => x.Brand).Include(x => x.categories).FirstOrDefaultAsync(x => x.Id == id);
        //    var bookVm = new BooksVM()
        //    {
        //        Id = bookDb.Id,
        //        Name = bookDb.Name,
        //        Description = bookDb.Description,
        //        pages = bookDb.pages,
        //        Price = bookDb.Price,
        //        Publisher = bookDb.Publisher,
        //        Brand = bookDb.Brand,
        //        Images = _nebulaContext.Attachments.Where(a => a.RecordId == bookDb.Id.ToString() && a.RecordType == Enum.RecordType.Books).Select(x => x.FileName).ToList()
        //    };
        //    var checkoutVm = new CheckoutVm()
        //    {
        //        bookId = id
        //    };
        //    return View(checkoutVm);

        //}

        [HttpPost]
        public async Task<IActionResult> Checkout(CheckoutVm checkout)
        {
            await _nebulaContext.AddAsync(new Orders()
            {
                FullName = checkout.FullName,
                Phone = checkout.Phone,
                Address = checkout.Address,
                City = checkout.City,
                Country = checkout.Country,
                Email = checkout.Email,
                bookId = checkout.bookId
            });
            await _nebulaContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

       
    }
}
