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
    public class KhachhangController : Controller
    {
        private readonly ApplicationDbContext _context;
        private StringProcess Ngid = new StringProcess();
        private ExcelProcess _excelProcess =new ExcelProcess();

        public KhachhangController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Khachhang
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Khachhang.Include(k => k.Nganhang);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Khachhang/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Khachhang == null)
            {
                return NotFound();
            }

            var khachhang = await _context.Khachhang
                .Include(k => k.Nganhang)
                .FirstOrDefaultAsync(m => m.MaKH == id);
            if (khachhang == null)
            {
                return NotFound();
            }

            return View(khachhang);
        }

        // GET: Khachhang/Create
        public IActionResult Create()
        {
            var newIDn ="KH030";
            var countNTN  =_context.Khachhang.Count();
            if(countNTN >0 )
            {
                var MaKH=_context.Khachhang.OrderByDescending(m=>m.MaKH).First().MaKH;
                newIDn = Ngid.AutoGenerateCode(MaKH);
            }
            ViewBag.newID= newIDn;
            //Khóa ngoại
            ViewData["TenNH"] = new SelectList(_context.Nganhang, "MaNH", "TenNH");
            return View();
        }

        // POST: Khachhang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaKH,TenKH,CoQuanKH,SoTKKH,TenNH,DiaChiKH,SDTKH,EmailKH")] Khachhang khachhang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(khachhang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TenNH"] = new SelectList(_context.Nganhang, "MaNH", "TenNH", khachhang.TenNH);
            return View(khachhang);
        }

        // GET: Khachhang/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Khachhang == null)
            {
                return NotFound();
            }

            var khachhang = await _context.Khachhang.FindAsync(id);
            if (khachhang == null)
            {
                return NotFound();
            }
            ViewData["TenNH"] = new SelectList(_context.Nganhang, "MaNH", "TenNH", khachhang.TenNH);
            return View(khachhang);
        }

        // POST: Khachhang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaKH,TenKH,CoQuanKH,SoTKKH,TenNH,DiaChiKH,SDTKH,EmailKH")] Khachhang khachhang)
        {
            if (id != khachhang.MaKH)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(khachhang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhachhangExists(khachhang.MaKH))
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
            ViewData["TenNH"] = new SelectList(_context.Nganhang, "MaNH", "TenNH", khachhang.TenNH);
            return View(khachhang);
        }

        // GET: Khachhang/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Khachhang == null)
            {
                return NotFound();
            }

            var khachhang = await _context.Khachhang
                .Include(k => k.Nganhang)
                .FirstOrDefaultAsync(m => m.MaKH == id);
            if (khachhang == null)
            {
                return NotFound();
            }

            return View(khachhang);
        }

        // POST: Khachhang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Khachhang == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Khachhang'  is null.");
            }
            var khachhang = await _context.Khachhang.FindAsync(id);
            if (khachhang != null)
            {
                _context.Khachhang.Remove(khachhang);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KhachhangExists(string id)
        {
          return (_context.Khachhang?.Any(e => e.MaKH == id)).GetValueOrDefault();
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
                            var emp = new Khachhang();

                            emp.MaKH=dt.Rows[i][0].ToString();
                            emp.TenKH=dt.Rows[i][1].ToString();
                            emp.CoQuanKH=dt.Rows[i][2].ToString();
                            emp.SoTKKH=dt.Rows[i][3].ToString();
                            emp.TenNH=dt.Rows[i][4].ToString();
                            emp.DiaChiKH=dt.Rows[i][5].ToString();
                            emp.SDTKH=dt.Rows[i][6].ToString();
                            emp.EmailKH=dt.Rows[i][7].ToString();

                            
                            _context.Khachhang.Add(emp);
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
