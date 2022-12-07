using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BTL_PTPMQL_NHOM12.Models.Process;
using BTL_PTPMQL_NHOM12.Models;

namespace BTL_PTPMQL_NHOM12.Controllers
{
    public class LoaidichvuController : Controller
    {
        private readonly ApplicationDbContext _context;
        private ExcelProcess _excelProcess =new ExcelProcess();
        public LoaidichvuController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Loaidichvu
        public async Task<IActionResult> Index()
        {
              return _context.Loaidichvu != null ? 
                          View(await _context.Loaidichvu.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Loaidichvu'  is null.");
        }

        // GET: Loaidichvu/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Loaidichvu == null)
            {
                return NotFound();
            }

            var loaidichvu = await _context.Loaidichvu
                .FirstOrDefaultAsync(m => m.MaLoaiDV == id);
            if (loaidichvu == null)
            {
                return NotFound();
            }

            return View(loaidichvu);
        }

        // GET: Loaidichvu/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Loaidichvu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaLoaiDV,TenLoaiDV,YeuCaudikem")] Loaidichvu loaidichvu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loaidichvu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loaidichvu);
        }

        // GET: Loaidichvu/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Loaidichvu == null)
            {
                return NotFound();
            }

            var loaidichvu = await _context.Loaidichvu.FindAsync(id);
            if (loaidichvu == null)
            {
                return NotFound();
            }
            return View(loaidichvu);
        }

        // POST: Loaidichvu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaLoaiDV,TenLoaiDV,YeuCaudikem")] Loaidichvu loaidichvu)
        {
            if (id != loaidichvu.MaLoaiDV)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loaidichvu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaidichvuExists(loaidichvu.MaLoaiDV))
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
            return View(loaidichvu);
        }

        // GET: Loaidichvu/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Loaidichvu == null)
            {
                return NotFound();
            }

            var loaidichvu = await _context.Loaidichvu
                .FirstOrDefaultAsync(m => m.MaLoaiDV == id);
            if (loaidichvu == null)
            {
                return NotFound();
            }

            return View(loaidichvu);
        }

        // POST: Loaidichvu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Loaidichvu == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Loaidichvu'  is null.");
            }
            var loaidichvu = await _context.Loaidichvu.FindAsync(id);
            if (loaidichvu != null)
            {
                _context.Loaidichvu.Remove(loaidichvu);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoaidichvuExists(string id)
        {
          return (_context.Loaidichvu?.Any(e => e.MaLoaiDV == id)).GetValueOrDefault();
        }
         ////Thêm upload
         public async Task<IActionResult> Upload()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if(file!=null)
            {
                string fileExtension =Path.GetExtension(file.FileName);
                if (fileExtension != ".xls" && fileExtension != ".xlsx")
                {
                    ModelState.AddModelError("","Please choose excel file to upload!");
                }
                else{
                    var FileName = DateTime.Now.ToShortTimeString() + fileExtension;
                    var filePath = Path.Combine(Directory.GetCurrentDirectory() + "/Uploads/Excels", FileName);
                    var fileLocation = new FileInfo(filePath).ToString();
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        //save file to sever
                        await file.CopyToAsync(stream);
                        var dt = _excelProcess.ExcelToDataTable(fileLocation);
                        for (int i=0; i < dt.Rows.Count; i++)
                        {
                            var emp = new Loaidichvu();

                            emp.MaLoaiDV=dt.Rows[i][0].ToString();
                            emp.TenLoaiDV=dt.Rows[i][1].ToString();
                            
                            _context.Loaidichvu.Add(emp);
                        }
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            return View();
    }
}
}
