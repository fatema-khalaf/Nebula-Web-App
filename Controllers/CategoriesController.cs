using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Nebula.Data;
using Nebula.Enum;
using Nebula.VM;
using Microsoft.AspNetCore.Hosting;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Nebula.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace Nebula.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        private NebulaContext _nebulaContext;
        private readonly IHostingEnvironment _hostingEnvironment;
        public CategoriesController(NebulaContext nebulaContext, IHostingEnvironment hostingEnvironment)
        {
            _nebulaContext = nebulaContext;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            var list = _nebulaContext.Categories.Where(x => x.IsDelete == false).Select(x => new CategoriesVm
            {
                ParentId = x.ParentId,
                Id = x.Id,
                Name = x.Name,
                Description=x.Description,
                CreatedDate = x.CreatedDate,
                Parent= _nebulaContext.Categories.FirstOrDefault(z => z.IsDelete == false && z.Id == x.ParentId).Name,
                ImageId = _nebulaContext.Attachments
                     .FirstOrDefault(r => r.RecordId == x.Id.ToString() && r.RecordType == RecordType.Categories)
                     .FileName
            });
            return View(list);
        }

        public IActionResult Create()
        {
            
            return View();
        }
        public IActionResult CreateSubCategory()
        {
            ViewBag.ListParentCategories = _nebulaContext.Categories.Where(x => x.IsDelete == false && x.ParentId == null).Select(x =>
             new SelectListItem()
             {
                 Text = x.Name,
                 Value = x.Id.ToString()
             }).ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoriesVm category, List<IFormFile> files)
        {
            var entity = await _nebulaContext.Categories.AddAsync(category.ToEntity());
            await _nebulaContext.SaveChangesAsync();
            if (files !=null)
                if (files.Count > 0)
                {
                    foreach(var file in files)
                    {
                        var imageId = Guid.NewGuid();
                        var uploads = Path.Combine(_hostingEnvironment.WebRootPath, $"uploads/Categories/{imageId}.png");
                        await using (var stream = System.IO.File.Create(uploads))
                        {
                            await file.CopyToAsync(stream);
                        }
                        var imge = new Attachments()
                        {
                            RecordId = entity.Entity.Id.ToString(),
                            FileName = imageId.ToString(),
                            RecordType = RecordType.Categories
                        };
                        await _nebulaContext.Attachments.AddAsync(imge);
                        await _nebulaContext.SaveChangesAsync();
                    }
                }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubCategory(CategoriesVm category, List<IFormFile> files)
        {
           
            var entity = await _nebulaContext.Categories.AddAsync(category.ToEntity());
            await _nebulaContext.SaveChangesAsync();
            if (files != null)
                if (files.Count > 0)
                {
                    foreach (var file in files)
                    {
                        var imageId = Guid.NewGuid();
                        var uploads = Path.Combine(_hostingEnvironment.WebRootPath, $"uploads/Categories/{imageId}.png");
                        await using (var stream = System.IO.File.Create(uploads))
                        {
                            await file.CopyToAsync(stream);
                        }
                        var imge = new Attachments()
                        {
                            RecordId = entity.Entity.Id.ToString(),
                            FileName = imageId.ToString(),
                            RecordType = RecordType.Categories
                        };
                        await _nebulaContext.Attachments.AddAsync(imge);
                        await _nebulaContext.SaveChangesAsync();
                    }
                }
            
            return RedirectToAction("Index");
        }
        

        //Edit sub category
        public async Task<IActionResult> Edit(int id)
        {
            // get category from DB
            //var categoryDb = _nebulaContext.Categories.SingleOrDefault(x => x.Id == id);

            var categoryDb = await _nebulaContext.Categories.FindAsync(id);
            //convert entity category to categoryVm
            var categoryVm = new CategoriesVm()
            {
                Id = categoryDb.Id,
                Name = categoryDb.Name,
                Description = categoryDb.Description,
                ParentId = categoryDb.ParentId
            };

            //get list images for this category
            var listImages = _nebulaContext.Attachments
                .Where(x => x.RecordId == categoryDb.Id.ToString() &&
                x.RecordType == RecordType.Categories)
                .Select(x => x.FileName);
            categoryVm.Images = listImages.ToList();

            //sub category parent
            ViewBag.ListParentCategories = _nebulaContext.Categories.Where(x => x.IsDelete == false && x.ParentId == null).Select(x =>
              new SelectListItem()
              {
                  Text = x.Name,
                  Value = x.Id.ToString()
              }).ToList();

            return View(categoryVm);
        }

        //delete image in Edit view
        public async Task<IActionResult> DeleteImage(string fileName)
        {
            var attachment = _nebulaContext.Attachments.FirstOrDefault(x => x.FileName== fileName);
            var categoryId = Convert.ToInt32(attachment.RecordId);
            _nebulaContext.Attachments.Remove(attachment);
            await _nebulaContext.SaveChangesAsync();
            return RedirectToAction("Edit", routeValues: new { id = categoryId });

        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoriesVm category, List<IFormFile> files)
        {
            //find category in Db
            var entity = await _nebulaContext.Categories.FindAsync(category.Id);
            
            //edit database records according to data from the view
            entity.Name = category.Name;
            entity.Description = category.Description;
            entity.ParentId = category.ParentId;
            await _nebulaContext.SaveChangesAsync();
            if (files != null)
                if (files.Count > 0)
                {
                    foreach (var file in files)
                    {
                        var imageId = Guid.NewGuid();
                        var uploads = Path.Combine(_hostingEnvironment.WebRootPath, $"uploads/Categories/{imageId}.png");
                        await using (var stream = System.IO.File.Create(uploads))
                        {
                            await file.CopyToAsync(stream);
                        }
                        var imge = new Attachments()
                        {
                            RecordId = entity.Id.ToString(),
                            FileName = imageId.ToString(),
                            RecordType = RecordType.Categories
                        };
                        await _nebulaContext.Attachments.AddAsync(imge);
                        await _nebulaContext.SaveChangesAsync();
                    }
                }     
            return RedirectToAction("Index");
        }

        //Delete
        public async Task<IActionResult> Delete(int id)
        {
            var authorDb = _nebulaContext.Categories.SingleOrDefault(x => x.Id == id);
            authorDb.IsDelete = true;
            //await must be used to give database time to save changes before redirecting to Index view  
            await _nebulaContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
