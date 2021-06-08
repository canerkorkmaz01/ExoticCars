using ExoticCars.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExoticCars.Controllers
{
    public class BrandsController : Controller
    {

        private readonly AppDbContext context;

        public BrandsController(
            AppDbContext context
            )
        {
            this.context = context;
        }

        public async Task<IActionResult> Index() => View(await context.Brands.ToListAsync());

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Brand model)
        {

            if (ModelState.IsValid)
            {
                context.Brands.Add(model);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
                return View(model);
        }


        public async Task<IActionResult> Edit(int id) {
            return View(await context.Brands.FindAsync(id)); 
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Brand model)
        {

            if (ModelState.IsValid)
            {
                context.Entry(model).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
                return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var model = await context.Brands.FindAsync(id);
            context.Entry(model).State = EntityState.Deleted;
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
