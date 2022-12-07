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
    public class DangkiController : Controller
    {
        private readonly ApplicationDbContext _context;
        private StringProcess Ngid = new StringProcess();

        public DangkiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Dangki
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Dangki.Include(d => d.Dichvu).Include(d => d.Khachhang);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Dangki/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Dangki == null)
            {
                return NotFound();
            }

            var dangki = await _context.Dangki
                .Include(d => d.Dichvu)
                .Include(d => d.Khachhang)
                .FirstOrDefaultAsync(m => m.MaDK == id);
            if (dangki == null)
            {
                return NotFound();
            }

            return View(dangki);
        }

        // GET: Dangki/Create
        public IActionResult Create()
        {
            //sinh mã tự động
            var newIDn ="MA0112";
            var countNTN  =_context.Dangki.Count();
            if(countNTN >0 )
            {
                var MaDK=_context.Dangki.OrderByDescending(m=>m.MaDK).First().MaDK;
                newIDn = Ngid.AutoGenerateCode(MaDK);
            }
            ViewBag.newID= newIDn;
            //Khóa ngoại
            ViewData["MaDV"] = new SelectList(_context.Dichvu, "MaDV", "MaDV");
            ViewData["MaKH"] = new SelectList(_context.Khachhang, "MaKH", "MaKH");
            return View();
        }

        // POST: Dangki/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaDK,MaKH,MaDV,NgayDangKi,SoLuong")] Dangki dangki)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dangki);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaDV"] = new SelectList(_context.Dichvu, "MaDV", "MaDV", dangki.MaDV);
            ViewData["MaKH"] = new SelectList(_context.Khachhang, "MaKH", "MaKH", dangki.MaKH);
            return View(dangki);
        }

        // GET: Dangki/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Dangki == null)
            {
                return NotFound();
            }

            var dangki = await _context.Dangki.FindAsync(id);
            if (dangki == null)
            {
                return NotFound();
            }
            ViewData["MaDV"] = new SelectList(_context.Dichvu, "MaDV", "MaDV", dangki.MaDV);
            ViewData["MaKH"] = new SelectList(_context.Khachhang, "MaKH", "MaKH", dangki.MaKH);
            return View(dangki);
        }

        // POST: Dangki/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaDK,MaKH,MaDV,NgayDangKi,SoLuong")] Dangki dangki)
        {
            if (id != dangki.MaDK)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dangki);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DangkiExists(dangki.MaDK))
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
            ViewData["MaDV"] = new SelectList(_context.Dichvu, "MaDV", "MaDV", dangki.MaDV);
            ViewData["MaKH"] = new SelectList(_context.Khachhang, "MaKH", "MaKH", dangki.MaKH);
            return View(dangki);
        }

        // GET: Dangki/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Dangki == null)
            {
                return NotFound();
            }

            var dangki = await _context.Dangki
                .Include(d => d.Dichvu)
                .Include(d => d.Khachhang)
                .FirstOrDefaultAsync(m => m.MaDK == id);
            if (dangki == null)
            {
                return NotFound();
            }

            return View(dangki);
        }

        // POST: Dangki/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Dangki == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Dangki'  is null.");
            }
            var dangki = await _context.Dangki.FindAsync(id);
            if (dangki != null)
            {
                _context.Dangki.Remove(dangki);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DangkiExists(string id)
        {
          return (_context.Dangki?.Any(e => e.MaDK == id)).GetValueOrDefault();
        }
    }
}
