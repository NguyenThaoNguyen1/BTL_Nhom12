using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BTL_PTPMQL_NHOM12.Models;
using BTL_PTPMQL_NHOM12.Models.Process;
namespace BTL_PTPMQL_NHOM12.Controllers
{
    public class DichvuController : Controller
    {
        private readonly ApplicationDbContext _context;
        private StringProcess Ngid = new StringProcess();

        public DichvuController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Dichvu
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Dichvu.Include(d => d.Loaidichvu);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Dichvu/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Dichvu == null)
            {
                return NotFound();
            }

            var dichvu = await _context.Dichvu
                .Include(d => d.Loaidichvu)
                .FirstOrDefaultAsync(m => m.MaDV == id);
            if (dichvu == null)
            {
                return NotFound();
            }

            return View(dichvu);
        }

        // GET: Dichvu/Create
        public IActionResult Create()
        {
             //sinh mã tự động
            var newIDn ="DV021";
            var countNTN  =_context.Dichvu.Count();
            if(countNTN >0 )
            {
                var MaDV=_context.Dichvu.OrderByDescending(m=>m.MaDV).First().MaDV;
                newIDn = Ngid.AutoGenerateCode(MaDV);
            }
            ViewBag.newID= newIDn;
            //Khóa ngoại
            ViewData["MaLoaiDV"] = new SelectList(_context.Loaidichvu, "MaLoaiDV", "MaLoaiDV");
            return View();
        }

        // POST: Dichvu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaDV,MaLoaiDV,TenDV,DonViTinh,DonGia,GhiChu")] Dichvu dichvu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dichvu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaLoaiDV"] = new SelectList(_context.Loaidichvu, "MaLoaiDV", "MaLoaiDV", dichvu.MaLoaiDV);
            return View(dichvu);
        }

        // GET: Dichvu/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Dichvu == null)
            {
                return NotFound();
            }

            var dichvu = await _context.Dichvu.FindAsync(id);
            if (dichvu == null)
            {
                return NotFound();
            }
            ViewData["MaLoaiDV"] = new SelectList(_context.Loaidichvu, "MaLoaiDV", "MaLoaiDV", dichvu.MaLoaiDV);
            return View(dichvu);
        }

        // POST: Dichvu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaDV,MaLoaiDV,TenDV,DonViTinh,DonGia,GhiChu")] Dichvu dichvu)
        {
            if (id != dichvu.MaDV)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dichvu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DichvuExists(dichvu.MaDV))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaLoaiDV"] = new SelectList(_context.Loaidichvu, "MaLoaiDV", "MaLoaiDV", dichvu.MaLoaiDV);
            return View(dichvu);
        }

        // GET: Dichvu/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Dichvu == null)
            {
                return NotFound();
            }

            var dichvu = await _context.Dichvu
                .Include(d => d.Loaidichvu)
                .FirstOrDefaultAsync(m => m.MaDV == id);
            if (dichvu == null)
            {
                return NotFound();
            }

            return View(dichvu);
        }

        // POST: Dichvu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Dichvu == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Dichvu'  is null.");
            }
            var dichvu = await _context.Dichvu.FindAsync(id);
            if (dichvu != null)
            {
                _context.Dichvu.Remove(dichvu);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DichvuExists(string id)
        {
          return (_context.Dichvu?.Any(e => e.MaDV == id)).GetValueOrDefault();
        }
    }
}
