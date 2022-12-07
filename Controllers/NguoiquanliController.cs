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
    public class NguoiquanliController : Controller
    {
        private readonly ApplicationDbContext _context;
        private StringProcess Ngid = new StringProcess();

        public NguoiquanliController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Nguoiquanli
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Nguoiquanli.Include(n => n.Phongban);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Nguoiquanli/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Nguoiquanli == null)
            {
                return NotFound();
            }

            var nguoiquanli = await _context.Nguoiquanli
                .Include(n => n.Phongban)
                .FirstOrDefaultAsync(m => m.MaQL == id);
            if (nguoiquanli == null)
            {
                return NotFound();
            }

            return View(nguoiquanli);
        }

        // GET: Nguoiquanli/Create
        public IActionResult Create()
        {
            //sinh mã tự động
            var newIDn ="QL11";
            var countNTN  =_context.Nguoiquanli.Count();
            if(countNTN >0 )
            {
                var MaQL=_context.Nguoiquanli.OrderByDescending(m=>m.MaQL).First().MaQL;
                newIDn = Ngid.AutoGenerateCode(MaQL);
            }
            ViewBag.newID= newIDn;
            //Khóa ngoại
            ViewData["TenPB"] = new SelectList(_context.Phongban, "MaPB", "TenPB");
            return View();
        }

        // POST: Nguoiquanli/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaQL,TenQL,TenPB,SoTKNQL,DiaChiNQL,SDTNQl,EmailNQL")] Nguoiquanli nguoiquanli)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nguoiquanli);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TenPB"] = new SelectList(_context.Phongban, "MaPB", "TenPB", nguoiquanli.TenPB);
            return View(nguoiquanli);
        }

        // GET: Nguoiquanli/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Nguoiquanli == null)
            {
                return NotFound();
            }

            var nguoiquanli = await _context.Nguoiquanli.FindAsync(id);
            if (nguoiquanli == null)
            {
                return NotFound();
            }
            ViewData["TenPB"] = new SelectList(_context.Phongban, "MaPB", "TenPB", nguoiquanli.TenPB);
            return View(nguoiquanli);
        }

        // POST: Nguoiquanli/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaQL,TenQL,TenPB,SoTKNQL,DiaChiNQL,SDTNQl,EmailNQL")] Nguoiquanli nguoiquanli)
        {
            if (id != nguoiquanli.MaQL)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nguoiquanli);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NguoiquanliExists(nguoiquanli.MaQL))
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
            ViewData["TenPB"] = new SelectList(_context.Phongban, "MaPB", "TenPB", nguoiquanli.TenPB);
            return View(nguoiquanli);
        }

        // GET: Nguoiquanli/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Nguoiquanli == null)
            {
                return NotFound();
            }

            var nguoiquanli = await _context.Nguoiquanli
                .Include(n => n.Phongban)
                .FirstOrDefaultAsync(m => m.MaQL == id);
            if (nguoiquanli == null)
            {
                return NotFound();
            }

            return View(nguoiquanli);
        }

        // POST: Nguoiquanli/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Nguoiquanli == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Nguoiquanli'  is null.");
            }
            var nguoiquanli = await _context.Nguoiquanli.FindAsync(id);
            if (nguoiquanli != null)
            {
                _context.Nguoiquanli.Remove(nguoiquanli);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NguoiquanliExists(string id)
        {
          return (_context.Nguoiquanli?.Any(e => e.MaQL == id)).GetValueOrDefault();
        }
    }
}
