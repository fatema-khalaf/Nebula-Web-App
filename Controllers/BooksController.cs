using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nebula.Data;
using Nebula.Enum;
using Nebula.Models;
using Nebula.VM;

namespace Nebula.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        public NebulaContext _nebulaContext { get; set; }

        // enable access to the root

        private readonly IHostingEnvironment _hostingEnvironment;
        public BooksController(NebulaContext nebulaContext, IHostingEnvironment hostingEnvironment)
        {
            _nebulaContext = nebulaContext;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            
            var book = _nebulaContext.Books.Where(x => x.IsDelete == false).ToList()
                .Select(x => new BooksVM()
                {
                    Id=x.Id,
                    Name=x.Name,
                    Description=x.Description,
                    Publisher=x.Publisher,
                    pages=x.pages,
                    Language=x.Language,
                    BrandId=x.BrandId,
                    categoryId=x.CategoryId,
                    Brand=x.Brand,
                    categories =x.categories,                  
                    Price=x.Price,
                    ImageId=_nebulaContext.Attachments.FirstOrDefault(r=> r.RecordId==x.Id.ToString()&& r.RecordType== RecordType.Books)?.FileName

                });
            return View(book);
        }

        public async Task<IActionResult> Edit(int id)
        {

            var bookDb = await _nebulaContext.Books.FindAsync(id);
            var bookVm = new BooksVM()
            {
                Id = bookDb.Id,
                Name = bookDb.Name,
                Description = bookDb.Description,
                categoryId = bookDb.CategoryId,
                BrandId = bookDb.BrandId,
                Price = bookDb.Price,
                pages=bookDb.pages,
                Publisher=bookDb.Publisher,
                Language=bookDb.Language,
                Images = _nebulaContext.Attachments.Where(r => r.RecordId == bookDb.Id.ToString() && r.RecordType == RecordType.Books).Select(r => r.FileName).ToList()
            };

            var listImages = _nebulaContext.Attachments
                .Where(x => x.RecordId == bookDb.Id.ToString() &&
                x.RecordType == RecordType.Books)
                .Select(x => x.FileName);
            bookVm.Images = listImages.ToList();

            ViewBag.ListCategories = _nebulaContext.Categories.Where(x => x.IsDelete == false && x.ParentId == null).Select(x =>
              new SelectListItem()
              {
                  Text = x.Name,
                  Value = x.Id.ToString()
              }).ToList();
            ViewBag.ListAuthors = _nebulaContext.Brands.Where(x => x.IsDelete == false).Select(x =>
              new SelectListItem()
              {
                  Text = x.Name,
                  Value = x.Id.ToString()
              }).ToList();

            return View(bookVm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BooksVM book, List<IFormFile> files)
        {
            var bookDb = await _nebulaContext.Books.FindAsync(book.Id);
            bookDb.BrandId = book.BrandId;
            bookDb.CategoryId = book.categoryId;
            bookDb.Description = book.Description;
            bookDb.pages = book.pages;
            bookDb.Price = book.Price;
            bookDb.Publisher = book.Publisher;
            bookDb.Name = book.Name;
            
            var entity = _nebulaContext.Books.Update(bookDb);
            await _nebulaContext.SaveChangesAsync();
            if (files != null)
                if (files.Count > 0)
                {
                    foreach (var file in files)
                    {
                        var imageId = Guid.NewGuid();
                        var uploads = Path.Combine(_hostingEnvironment.WebRootPath, $"uploads/Books/{imageId}.png");
                        await using (var stream = System.IO.File.Create(uploads))
                        {
                            await file.CopyToAsync(stream);
                        }
                        var imge = new Attachments()
                        {
                            RecordId = bookDb.Id.ToString(),
                            FileName = imageId.ToString(),
                            RecordType = RecordType.Books
                        };
                        await _nebulaContext.Attachments.AddAsync(imge);
                        await _nebulaContext.SaveChangesAsync();
                    }
                }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteImage(string fileName)
        {
            var attachment = _nebulaContext.Attachments.FirstOrDefault(x => x.FileName == fileName);
            var categoryId = Convert.ToInt32(attachment.RecordId);
            _nebulaContext.Attachments.Remove(attachment);
            await _nebulaContext.SaveChangesAsync();
            return RedirectToAction("Edit", routeValues: new { id = categoryId });

        }


        public IActionResult Create()
        {
            ViewBag.ListCategories = _nebulaContext.Categories.Where(x => x.IsDelete == false).Select(x =>
              new SelectListItem()
              {
                  Text = x.Name,
                  Value = x.Id.ToString()
              }).ToList();
            ViewBag.Authors = _nebulaContext.Brands.Where(x => x.IsDelete == false).Select(x =>
              new SelectListItem()
              {
                  Text = x.Name,
                  Value = x.Id.ToString()
              }).ToList();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BooksVM book, List<IFormFile> files)
        {
            var entity = await _nebulaContext.Books.AddAsync(book.ToEntity());
            await _nebulaContext.SaveChangesAsync();
            if (files != null)
                if (files.Count > 0)
                {
                    foreach (var file in files)
                    {
                        var imageId = Guid.NewGuid();
                        var uploads = Path.Combine(_hostingEnvironment.WebRootPath, $"uploads/Books/{imageId}.png");
                        await using (var stream = System.IO.File.Create(uploads))
                        {
                            await file.CopyToAsync(stream);
                        }
                        var imge = new Attachments()
                        {
                            RecordId = entity.Entity.Id.ToString(),
                            FileName = imageId.ToString(),
                            RecordType = RecordType.Books,
                        };
                        await _nebulaContext.Attachments.AddAsync(imge);
                        await _nebulaContext.SaveChangesAsync();
                    }
                }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var BookDb =await _nebulaContext.Books.FindAsync(id);
            BookDb.IsDelete = true;
            //await must be used to give database time to save changes before redirecting to Index view
            _nebulaContext.Books.Update(BookDb);
            await _nebulaContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public IActionResult Orders()
        {
            var list = _nebulaContext.Orders.ToList().Select(x => new CheckoutVm()
            {
                Id = x.Id,
                bookId=x.bookId,
                Address=x.Address,
                FullName=x.FullName,
                City= x.City,
                Country= x.Country,
                Email=x.Email,
                Phone=x.Phone,
                OrderStatus=x.OrderStatus,
           });
            return View(list);
        }

        public async Task<IActionResult> ChangeStatuse(OrderStatus status , int id)
        {
            var order = _nebulaContext.Orders.FirstOrDefault(x => x.Id==id);
            order.OrderStatus = status;
            await _nebulaContext.SaveChangesAsync();
            return RedirectToAction("Orders");
        }



    }
}
