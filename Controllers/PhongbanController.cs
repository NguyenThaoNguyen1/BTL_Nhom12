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
    public class PhongbanController : Controller
    {
        private readonly ApplicationDbContext _context;
        private ExcelProcess _excelProcess =new ExcelProcess();

        public PhongbanController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Phongban
        // public async Task<IActionResult> Index()
        // {
        //       return _context.Phongban != null ? 
        //                   View(await _context.Phongban.ToListAsync()) :
        //                   Problem("Entity set 'ApplicationDbContext.Phongban'  is null.");
        // }
          //Tìm kiếm
        public async Task<IActionResult> Index(string TimkiemPB, string searchString)
        {
            if (_context.Phongban == null)
            {
                return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
            }

            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Phongban
                                            orderby m.TenPB
                                            select m.TenPB;
            var Phongban = from m in _context.Phongban
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                Phongban = Phongban.Where(s => s.TenPB!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(TimkiemPB))
            {
                Phongban = Phongban.Where(x => x.TenPB == TimkiemPB);
            }

            var movieGenreVM = new MovieGenreViewModel
            {
                TenPB = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Phongban = await Phongban.ToListAsync()
            };

            return View(movieGenreVM);
        }
        ////Kết thúc tìm kiếm

        // GET: Phongban/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Phongban == null)
            {
                return NotFound();
            }

            var phongban = await _context.Phongban
                .FirstOrDefaultAsync(m => m.MaPB == id);
            if (phongban == null)
            {
                return NotFound();
            }

            return View(phongban);
        }

        // GET: Phongban/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Phongban/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaPB,TenPB")] Phongban phongban)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phongban);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(phongban);
        }

        // GET: Phongban/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Phongban == null)
            {
                return NotFound();
            }

            var phongban = await _context.Phongban.FindAsync(id);
            if (phongban == null)
            {
                return NotFound();
            }
            return View(phongban);
        }

        // POST: Phongban/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaPB,TenPB")] Phongban phongban)
        {
            if (id != phongban.MaPB)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phongban);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhongbanExists(phongban.MaPB))
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
            return View(phongban);
        }

        // GET: Phongban/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Phongban == null)
            {
                return NotFound();
            }

            var phongban = await _context.Phongban
                .FirstOrDefaultAsync(m => m.MaPB == id);
            if (phongban == null)
            {
                return NotFound();
            }

            return View(phongban);
        }

        // POST: Phongban/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Phongban == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Phongban'  is null.");
            }
            var phongban = await _context.Phongban.FindAsync(id);
            if (phongban != null)
            {
                _context.Phongban.Remove(phongban);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhongbanExists(string id)
        {
          return (_context.Phongban?.Any(e => e.MaPB == id)).GetValueOrDefault();
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
                            var emp = new Phongban();

                            emp.MaPB=dt.Rows[i][0].ToString();
                            emp.TenPB=dt.Rows[i][1].ToString();
                            
                            _context.Phongban.Add(emp);
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
