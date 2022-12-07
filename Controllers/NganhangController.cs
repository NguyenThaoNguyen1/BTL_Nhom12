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
    public class NganhangController : Controller
    {
        private readonly ApplicationDbContext _context;
        private ExcelProcess _excelProcess =new ExcelProcess();


        public NganhangController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Nganhang
        // public async Task<IActionResult> Index()
        // {
        //       return _context.Nganhang != null ? 
        //                   View(await _context.Nganhang.ToListAsync()) :
        //                   Problem("Entity set 'ApplicationDbContext.Nganhang'  is null.");
        // }
        
      //Tìm kiếm
        public async Task<IActionResult> Index(string TimkiemNH, string searchString)
        {
            if (_context.Nganhang == null)
            {
                return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
            }

            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Nganhang
                                            orderby m.TenNH
                                            select m.TenNH;
            var Nganhang = from m in _context.Nganhang
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                Nganhang = Nganhang.Where(s => s.TenNH!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(TimkiemNH))
            {
                Nganhang = Nganhang.Where(x => x.TenNH == TimkiemNH);
            }

            var movieGenreVM = new MovieGenreViewModel
            {
                TenNH = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Nganhang = await Nganhang.ToListAsync()
            };

            return View(movieGenreVM);
        }
        ////Kết thúc tìm kiếm

        // GET: Nganhang/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Nganhang == null)
            {
                return NotFound();
            }

            var nganhang = await _context.Nganhang
                .FirstOrDefaultAsync(m => m.MaNH == id);
            if (nganhang == null)
            {
                return NotFound();
            }

            return View(nganhang);
        }

        // GET: Nganhang/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nganhang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaNH,TenNH")] Nganhang nganhang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nganhang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nganhang);
        }

        // GET: Nganhang/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Nganhang == null)
            {
                return NotFound();
            }

            var nganhang = await _context.Nganhang.FindAsync(id);
            if (nganhang == null)
            {
                return NotFound();
            }
            return View(nganhang);
        }

        // POST: Nganhang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaNH,TenNH")] Nganhang nganhang)
        {
            if (id != nganhang.MaNH)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nganhang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NganhangExists(nganhang.MaNH))
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
            return View(nganhang);
        }

        // GET: Nganhang/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Nganhang == null)
            {
                return NotFound();
            }

            var nganhang = await _context.Nganhang
                .FirstOrDefaultAsync(m => m.MaNH == id);
            if (nganhang == null)
            {
                return NotFound();
            }

            return View(nganhang);
        }

        // POST: Nganhang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Nganhang == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Nganhang'  is null.");
            }
            var nganhang = await _context.Nganhang.FindAsync(id);
            if (nganhang != null)
            {
                _context.Nganhang.Remove(nganhang);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NganhangExists(string id)
        {
          return (_context.Nganhang?.Any(e => e.MaNH == id)).GetValueOrDefault();
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
                            var emp = new Nganhang();

                            emp.MaNH=dt.Rows[i][0].ToString();
                            emp.TenNH=dt.Rows[i][1].ToString();
                    
                            _context.Nganhang.Add(emp);
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
