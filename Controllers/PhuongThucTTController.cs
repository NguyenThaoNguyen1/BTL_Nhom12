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
    public class PhuongThucTTController : Controller
    {
        private readonly ApplicationDbContext _context;
        private ExcelProcess _excelProcess =new ExcelProcess();
        public PhuongThucTTController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PhuongThucTT
        public async Task<IActionResult> Index()
        {
              return _context.PhuongThucTT != null ? 
                          View(await _context.PhuongThucTT.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.PhuongThucTT'  is null.");
        }

        // GET: PhuongThucTT/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.PhuongThucTT == null)
            {
                return NotFound();
            }

            var phuongThucTT = await _context.PhuongThucTT
                .FirstOrDefaultAsync(m => m.MaPT == id);
            if (phuongThucTT == null)
            {
                return NotFound();
            }

            return View(phuongThucTT);
        }

        // GET: PhuongThucTT/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PhuongThucTT/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaPT,PhuongThucthanhToan")] PhuongThucTT phuongThucTT)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phuongThucTT);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(phuongThucTT);
        }

        // GET: PhuongThucTT/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.PhuongThucTT == null)
            {
                return NotFound();
            }

            var phuongThucTT = await _context.PhuongThucTT.FindAsync(id);
            if (phuongThucTT == null)
            {
                return NotFound();
            }
            return View(phuongThucTT);
        }

        // POST: PhuongThucTT/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaPT,PhuongThucthanhToan")] PhuongThucTT phuongThucTT)
        {
            if (id != phuongThucTT.MaPT)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phuongThucTT);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhuongThucTTExists(phuongThucTT.MaPT))
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
            return View(phuongThucTT);
        }

        // GET: PhuongThucTT/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.PhuongThucTT == null)
            {
                return NotFound();
            }

            var phuongThucTT = await _context.PhuongThucTT
                .FirstOrDefaultAsync(m => m.MaPT == id);
            if (phuongThucTT == null)
            {
                return NotFound();
            }

            return View(phuongThucTT);
        }

        // POST: PhuongThucTT/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.PhuongThucTT == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PhuongThucTT'  is null.");
            }
            var phuongThucTT = await _context.PhuongThucTT.FindAsync(id);
            if (phuongThucTT != null)
            {
                _context.PhuongThucTT.Remove(phuongThucTT);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhuongThucTTExists(string id)
        {
          return (_context.PhuongThucTT?.Any(e => e.MaPT == id)).GetValueOrDefault();
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
                            var emp = new PhuongThucTT();

                            emp.MaPT=dt.Rows[i][0].ToString();
                            emp.PhuongThucthanhToan=dt.Rows[i][1].ToString();
                            
                            _context.PhuongThucTT.Add(emp);
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
