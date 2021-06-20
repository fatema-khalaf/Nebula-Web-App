using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nebula.Data;
using Nebula.Models;
using Nebula.VM;

namespace Nebula.Controllers
{
    [Authorize]
    public class BrandsController : Controller
    {
        //object of nebulacontext class to connect with the database
        public NebulaContext _nebulaContext { get; set; }

        // enable access to the root

        private readonly IHostingEnvironment _hostingEnvironment;
        public BrandsController (NebulaContext nebulaContext, IHostingEnvironment hostingEnvironment)
        {
            _nebulaContext = nebulaContext;
            _hostingEnvironment = hostingEnvironment;
        }

        //display data from db on Authors' view
        public IActionResult Index()
        {
            var listBrands = _nebulaContext.Brands
                .Where(x => x.IsDelete == false)
                .Select(x =>
                new BrandsVm()
                {
                    Name = x.Name,
                    Id = x.Id,
                    Description=x.Description,
                    CreatedBy=x.CreatedBy,
                    CreatedDate = x.CreatedDate,
                    ImageId=x.ImageId
                }
                ).ToList();
            return View(listBrands);
        }

        //view "Add new author" page
        public IActionResult Create()
        {
            return View();
        }

        //recive and hold the data from the view
        [HttpPost]
        public async Task <IActionResult> Create(BrandsVm brand, IFormFile file)
        {
            // assign values from the viwe to a Brands' object
            var newBrand = new Brands() { Name = brand.Name, Description = brand.Description };
            // upload image file
            if (file.Length > 0)
            {
                var imgId = Guid.NewGuid();
                var uploads = Path.Combine(_hostingEnvironment.WebRootPath, $"uploads/Brands/{imgId}.png");
                using (var stream = System.IO.File.Create(uploads))
                {
                    await file.CopyToAsync(stream);
                }
                newBrand.ImageId = imgId.ToString();
            }
            await _nebulaContext.Brands.AddAsync(newBrand);// add values to the db
            await _nebulaContext.SaveChangesAsync();// save changes in the db
            return View();
        }

        //Edit viwe method
        public IActionResult Edit(int id)
        {
            //get Author from db where id ==id
            var AuthorDb = _nebulaContext.Brands.SingleOrDefault(x => x.Id == id);
            // assign values from db to a BrandsVm' object
            var Author = new BrandsVm()
            {
                Id = AuthorDb.Id,
                Name = AuthorDb.Name,
                Description = AuthorDb.Description,
                ImageId = AuthorDb.ImageId

            };
            // disply the valus on Edit view 
            return View(Author);
        }
        [HttpPost]
        public async Task<IActionResult> Edit (BrandsVm author, IFormFile file)
        {
            var authorDb = _nebulaContext.Brands.SingleOrDefault(x => x.Id == author.Id);
            authorDb.Name = author.Name;
            authorDb.Description = author.Description;
            authorDb.LastModify = DateTime.Now;
            // upload image file
            if (file.Length > 0)
            {
                var imgId = Guid.NewGuid();
                var uploads = Path.Combine(_hostingEnvironment.WebRootPath, $"uploads/Brands/{imgId}.png");
                using (var stream = System.IO.File.Create(uploads))
                {
                    await file.CopyToAsync(stream);
                }
                authorDb.ImageId = imgId.ToString();
            }
            //await must be used to give database time to save changes before redirecting to Index view  
            await _nebulaContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        
        //Soft delete
        public async Task<IActionResult> Delete(int id)
        {
            var authorDb = _nebulaContext.Brands.SingleOrDefault(x => x.Id == id);
            authorDb.IsDelete = true;
            //await must be used to give database time to save changes before redirecting to Index view  
            await _nebulaContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Restore()
        {
            var listBrands = _nebulaContext.Brands
                .Where(x => x.IsDelete == true)
                .Select(x =>
                new BrandsVm()
                {
                    Name = x.Name,
                    Id = x.Id,
                    Description = x.Description,
                    CreatedBy = x.CreatedBy,
                    CreatedDate = x.CreatedDate,
                    ImageId = x.ImageId
                }
                ).ToList();
            return View(listBrands);
        }
        public async Task<IActionResult>Restore2(int id)
        {

            var authorDb = _nebulaContext.Brands.SingleOrDefault(x => x.Id == id);
            authorDb.IsDelete = false;
            //await must be used to give database time to save changes before redirecting to Index view  
            await _nebulaContext.SaveChangesAsync();
            return RedirectToAction("Restore");

        }
        

        public async Task<IActionResult> FinalDelete(int id)
        {
            var authorDb = _nebulaContext.Brands.SingleOrDefault(x => x.Id == id);
            _nebulaContext.Brands.Remove(authorDb);
            //await must be used to give database time to save changes before redirecting to Index view  
            await _nebulaContext.SaveChangesAsync();
            return RedirectToAction("Restore");
        }

    }
}
