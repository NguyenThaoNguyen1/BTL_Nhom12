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
    public class KyhopdongController : Controller
    {
        private readonly ApplicationDbContext _context;
        private StringProcess Ngid = new StringProcess();

        public KyhopdongController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Kyhopdong
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Kyhopdong.Include(k => k.Dichvu).Include(k => k.Khachhang).Include(k => k.Nguoiquanli).Include(k => k.PhuongThucTT);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Kyhopdong/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Kyhopdong == null)
            {
                return NotFound();
            }

            var kyhopdong = await _context.Kyhopdong
                .Include(k => k.Dichvu)
                .Include(k => k.Khachhang)
                .Include(k => k.Nguoiquanli)
                .Include(k => k.PhuongThucTT)
                .FirstOrDefaultAsync(m => m.SoHD == id);
            if (kyhopdong == null)
            {
                return NotFound();
            }

            return View(kyhopdong);
        }

        // GET: Kyhopdong/Create
        public IActionResult Create()
        {
            //sinh mã tự động
            var newIDn ="HD0001";
            var countNTN  =_context.Kyhopdong.Count();
            if(countNTN >0 )
            {
                var SoHD=_context.Kyhopdong.OrderByDescending(m=>m.SoHD).First().SoHD;
                newIDn = Ngid.AutoGenerateCode(SoHD);
            }
            ViewBag.newID= newIDn;
            //Khóa ngoại
            ViewData["MaDV"] = new SelectList(_context.Dichvu, "MaDV", "MaDV");
            ViewData["MaKH"] = new SelectList(_context.Khachhang, "MaKH", "MaKH");
            ViewData["MaQL"] = new SelectList(_context.Nguoiquanli, "MaQL", "MaQL");
            ViewData["PhuongThucThanhToan"] = new SelectList(_context.PhuongThucTT, "MaPT", "PhuongThucthanhToan");
            return View();
        }

        // POST: Kyhopdong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SoHD,MaQL,MaKH,MaDV,NoiDung,DiaDiem,NgayKi,ThoiGianThanhToan,PhuongThucThanhToan,TrachNhiemChung")] Kyhopdong kyhopdong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kyhopdong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaDV"] = new SelectList(_context.Dichvu, "MaDV", "MaDV", kyhopdong.MaDV);
            ViewData["MaKH"] = new SelectList(_context.Khachhang, "MaKH", "MaKH", kyhopdong.MaKH);
            ViewData["MaQL"] = new SelectList(_context.Nguoiquanli, "MaQL", "MaQL", kyhopdong.MaQL);
            ViewData["PhuongThucThanhToan"] = new SelectList(_context.PhuongThucTT, "MaPT", "PhuongThucthanhToan", kyhopdong.PhuongThucThanhToan);
            return View(kyhopdong);
        }

        // GET: Kyhopdong/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Kyhopdong == null)
            {
                return NotFound();
            }

            var kyhopdong = await _context.Kyhopdong.FindAsync(id);
            if (kyhopdong == null)
            {
                return NotFound();
            }
            ViewData["MaDV"] = new SelectList(_context.Dichvu, "MaDV", "MaDV", kyhopdong.MaDV);
            ViewData["MaKH"] = new SelectList(_context.Khachhang, "MaKH", "MaKH", kyhopdong.MaKH);
            ViewData["MaQL"] = new SelectList(_context.Nguoiquanli, "MaQL", "MaQL", kyhopdong.MaQL);
            ViewData["PhuongThucThanhToan"] = new SelectList(_context.PhuongThucTT, "MaPT", "PhuongThucthanhToan", kyhopdong.PhuongThucThanhToan);
            return View(kyhopdong);
        }

        // POST: Kyhopdong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("SoHD,MaQL,MaKH,MaDV,NoiDung,DiaDiem,NgayKi,ThoiGianThanhToan,PhuongThucThanhToan,TrachNhiemChung")] Kyhopdong kyhopdong)
        {
            if (id != kyhopdong.SoHD)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kyhopdong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KyhopdongExists(kyhopdong.SoHD))
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
            ViewData["MaDV"] = new SelectList(_context.Dichvu, "MaDV", "MaDV", kyhopdong.MaDV);
            ViewData["MaKH"] = new SelectList(_context.Khachhang, "MaKH", "MaKH", kyhopdong.MaKH);
            ViewData["MaQL"] = new SelectList(_context.Nguoiquanli, "MaQL", "MaQL", kyhopdong.MaQL);
            ViewData["PhuongThucThanhToan"] = new SelectList(_context.PhuongThucTT, "MaPT", "PhuongThucthanhToan", kyhopdong.PhuongThucThanhToan);
            return View(kyhopdong);
        }

        // GET: Kyhopdong/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Kyhopdong == null)
            {
                return NotFound();
            }

            var kyhopdong = await _context.Kyhopdong
                .Include(k => k.Dichvu)
                .Include(k => k.Khachhang)
                .Include(k => k.Nguoiquanli)
                .Include(k => k.PhuongThucTT)
                .FirstOrDefaultAsync(m => m.SoHD == id);
            if (kyhopdong == null)
            {
                return NotFound();
            }

            return View(kyhopdong);
        }

        // POST: Kyhopdong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Kyhopdong == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Kyhopdong'  is null.");
            }
            var kyhopdong = await _context.Kyhopdong.FindAsync(id);
            if (kyhopdong != null)
            {
                _context.Kyhopdong.Remove(kyhopdong);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KyhopdongExists(string id)
        {
          return (_context.Kyhopdong?.Any(e => e.SoHD == id)).GetValueOrDefault();
        }
    }
}
