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
    public class NhanvienController : Controller
    {
        private readonly ApplicationDbContext _context;
        private StringProcess Ngid = new StringProcess();
        private ExcelProcess _excelProcess =new ExcelProcess();

        public NhanvienController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Nhanvien
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Nhanvien.Include(n => n.Phongban);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Nhanvien/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Nhanvien == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Nhanvien
                .Include(n => n.Phongban)
                .FirstOrDefaultAsync(m => m.MaNV == id);
            if (nhanvien == null)
            {
                return NotFound();
            }

            return View(nhanvien);
        }

        // GET: Nhanvien/Create
        public IActionResult Create()
        {
            //sinh mã tự động
            var newIDn ="NV001";
            var countNTN  =_context.Nhanvien.Count();
            if(countNTN >0 )
            {
                var MaNV=_context.Nhanvien.OrderByDescending(m=>m.MaNV).First().MaNV;
                newIDn = Ngid.AutoGenerateCode(MaNV);
            }
            ViewBag.newID= newIDn;
            // khóa ngoại
            ViewData["TenPB"] = new SelectList(_context.Phongban, "MaPB", "TenPB");
            return View();
        }

        // POST: Nhanvien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaNV,TenNV,GioiTinhNV,TenPB,DiaChiNV,EmailNV,SDTNV,ChucVuNV")] Nhanvien nhanvien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhanvien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TenPB"] = new SelectList(_context.Phongban, "MaPB", "TenPB", nhanvien.TenPB);
            return View(nhanvien);
        }

        // GET: Nhanvien/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Nhanvien == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Nhanvien.FindAsync(id);
            if (nhanvien == null)
            {
                return NotFound();
            }
            ViewData["TenPB"] = new SelectList(_context.Phongban, "MaPB", "TenPB", nhanvien.TenPB);
            return View(nhanvien);
        }

        // POST: Nhanvien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaNV,TenNV,GioiTinhNV,TenPB,DiaChiNV,EmailNV,SDTNV,ChucVuNV")] Nhanvien nhanvien)
        {
            if (id != nhanvien.MaNV)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhanvien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhanvienExists(nhanvien.MaNV))
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
            ViewData["TenPB"] = new SelectList(_context.Phongban, "MaPB", "TenPB", nhanvien.TenPB);
            return View(nhanvien);
        }

        // GET: Nhanvien/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Nhanvien == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Nhanvien
                .Include(n => n.Phongban)
                .FirstOrDefaultAsync(m => m.MaNV == id);
            if (nhanvien == null)
            {
                return NotFound();
            }

            return View(nhanvien);
        }

        // POST: Nhanvien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Nhanvien == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Nhanvien'  is null.");
            }
            var nhanvien = await _context.Nhanvien.FindAsync(id);
            if (nhanvien != null)
            {
                _context.Nhanvien.Remove(nhanvien);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhanvienExists(string id)
        {
          return (_context.Nhanvien?.Any(e => e.MaNV == id)).GetValueOrDefault();
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
                            var emp = new Nhanvien();

                            emp.MaNV=dt.Rows[i][0].ToString();
                            emp.TenNV=dt.Rows[i][1].ToString();
                            emp.GioiTinhNV=dt.Rows[i][2].ToString();
                            emp.TenPB=dt.Rows[i][3].ToString();
                            emp.DiaChiNV=dt.Rows[i][4].ToString();
                            emp.EmailNV=dt.Rows[i][5].ToString();
                            emp.SDTNV=dt.Rows[i][6].ToString();
                            emp.ChucVuNV=dt.Rows[i][7].ToString();
                            
                            _context.Nhanvien.Add(emp);
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
