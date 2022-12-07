using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BTL_PTPMQL_NHOM12.Models;

namespace BTL_PTPMQL_NHOM12.Controllers
{
    public class GiaonhanController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GiaonhanController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Giaonhan
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Giaonhan.Include(g => g.Dichvu).Include(g => g.Nguoiquanli).Include(g => g.Nhanvien);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Giaonhan/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Giaonhan == null)
            {
                return NotFound();
            }

            var giaonhan = await _context.Giaonhan
                .Include(g => g.Dichvu)
                .Include(g => g.Nguoiquanli)
                .Include(g => g.Nhanvien)
                .FirstOrDefaultAsync(m => m.MaQL == id);
            if (giaonhan == null)
            {
                return NotFound();
            }

            return View(giaonhan);
        }

        // GET: Giaonhan/Create
        public IActionResult Create()
        {
            ViewData["MaDV"] = new SelectList(_context.Dichvu, "MaDV", "MaDV");
            ViewData["MaQL"] = new SelectList(_context.Nguoiquanli, "MaQL", "MaQL");
            ViewData["MaNV"] = new SelectList(_context.Nhanvien, "MaNV", "MaNV");
            return View();
        }

        // POST: Giaonhan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaQL,MaNV,MaDV,TrangThaiHienTai,NgayGiao,NgayHoanThanh")] Giaonhan giaonhan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(giaonhan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaDV"] = new SelectList(_context.Dichvu, "MaDV", "MaDV", giaonhan.MaDV);
            ViewData["MaQL"] = new SelectList(_context.Nguoiquanli, "MaQL", "MaQL", giaonhan.MaQL);
            ViewData["MaNV"] = new SelectList(_context.Nhanvien, "MaNV", "MaNV", giaonhan.MaNV);
            return View(giaonhan);
        }

        // GET: Giaonhan/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Giaonhan == null)
            {
                return NotFound();
            }

            var giaonhan = await _context.Giaonhan.FindAsync(id);
            if (giaonhan == null)
            {
                return NotFound();
            }
            ViewData["MaDV"] = new SelectList(_context.Dichvu, "MaDV", "MaDV", giaonhan.MaDV);
            ViewData["MaQL"] = new SelectList(_context.Nguoiquanli, "MaQL", "MaQL", giaonhan.MaQL);
            ViewData["MaNV"] = new SelectList(_context.Nhanvien, "MaNV", "MaNV", giaonhan.MaNV);
            return View(giaonhan);
        }

        // POST: Giaonhan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaQL,MaNV,MaDV,TrangThaiHienTai,NgayGiao,NgayHoanThanh")] Giaonhan giaonhan)
        {
            if (id != giaonhan.MaQL)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(giaonhan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GiaonhanExists(giaonhan.MaQL))
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
            ViewData["MaDV"] = new SelectList(_context.Dichvu, "MaDV", "MaDV", giaonhan.MaDV);
            ViewData["MaQL"] = new SelectList(_context.Nguoiquanli, "MaQL", "MaQL", giaonhan.MaQL);
            ViewData["MaNV"] = new SelectList(_context.Nhanvien, "MaNV", "MaNV", giaonhan.MaNV);
            return View(giaonhan);
        }

        // GET: Giaonhan/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Giaonhan == null)
            {
                return NotFound();
            }

            var giaonhan = await _context.Giaonhan
                .Include(g => g.Dichvu)
                .Include(g => g.Nguoiquanli)
                .Include(g => g.Nhanvien)
                .FirstOrDefaultAsync(m => m.MaQL == id);
            if (giaonhan == null)
            {
                return NotFound();
            }

            return View(giaonhan);
        }

        // POST: Giaonhan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Giaonhan == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Giaonhan'  is null.");
            }
            var giaonhan = await _context.Giaonhan.FindAsync(id);
            if (giaonhan != null)
            {
                _context.Giaonhan.Remove(giaonhan);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GiaonhanExists(string id)
        {
          return (_context.Giaonhan?.Any(e => e.MaQL == id)).GetValueOrDefault();
        }
    }
}
