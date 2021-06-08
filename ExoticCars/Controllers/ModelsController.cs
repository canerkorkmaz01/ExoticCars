using ExoticCars.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExoticCars.Controllers
{
    public class ModelsController : Controller
    {

        private readonly AppDbContext context;

        public ModelsController(
            AppDbContext context
            )
        {
            this.context = context;
        }

        public async Task<IActionResult> Index() => View(await context.Models.Include(p=>p.Brand).ToListAsync());

        public async Task<IActionResult> Create()
        {
            ViewBag.Brands = new SelectList(await context.Brands.ToListAsync(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Model model)
        {

            if (ModelState.IsValid)
            {
                context.Models.Add(model);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Brands = new SelectList(await context.Brands.ToListAsync(), "Id", "Name");
                return View(model);
            }
        }


        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Brands = new SelectList(await context.Brands.ToListAsync(), "Id", "Name");
            return View(await context.Models.FindAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Model model)
        {

            if (ModelState.IsValid)
            {
                context.Entry(model).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Brands = new SelectList(await context.Brands.ToListAsync(), "Id", "Name");
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var model = await context.Models.FindAsync(id);
            context.Entry(model).State = EntityState.Deleted;
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
