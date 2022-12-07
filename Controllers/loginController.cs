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
    public class loginController : Controller
    {
        private readonly ApplicationDbContext _context;

        public loginController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: login
        public async Task<IActionResult> Index()
        {
            return _context.login != null ?
                        View(await _context.login.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.login'  is null.");
        }

        // GET: login/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.login == null)
            {
                return NotFound();
            }

            var login = await _context.login
                .FirstOrDefaultAsync(m => m.User == id);
            if (login == null)
            {
                return NotFound();
            }

            return View(login);
        }

        // GET: login/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: login/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("User,Password")] login login)
        {
            if (!ModelState.IsValid) return View(login);


            if (login.User =="admin"&&login.Password =="1"||login.User =="Nguyen"&&login.Password =="123")
            {
                TempData["Login"] = "Login";
                return RedirectToAction("Index", "Home");

            }else{
            TempData["Error"] = "Mật khẩu sai. Mời bạn nhập lại mật khẩu!";
            return View(login);
            } 
        }

        // GET: login/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.login == null)
            {
                return NotFound();
            }

            var login = await _context.login.FindAsync(id);
            if (login == null)
            {
                return NotFound();
            }
            return View(login);
        }

        // POST: login/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("User,Password")] login login)
        {
            if (id != login.User)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(login);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!loginExists(login.User))
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
            return View(login);
        }

        // GET: login/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.login == null)
            {
                return NotFound();
            }

            var login = await _context.login
                .FirstOrDefaultAsync(m => m.User == id);
            if (login == null)
            {
                return NotFound();
            }

            return View(login);
        }

        // POST: login/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.login == null)
            {
                return Problem("Entity set 'ApplicationDbContext.login'  is null.");
            }
            var login = await _context.login.FindAsync(id);
            if (login != null)
            {
                _context.login.Remove(login);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool loginExists(string id)
        {
            return (_context.login?.Any(e => e.User == id)).GetValueOrDefault();
        }
    }
}
