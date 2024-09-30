using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VendorMate.Models;
using YourNamespace.Models;

namespace VendorMate.Controllers
{
    public class VendorMasterController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VendorMasterController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VendorMaster
        public async Task<IActionResult> Index()
        {
            return View(await _context.VendorMaster.ToListAsync());
        }

        // GET: VendorMaster/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VendorMaster/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Code,Name,AddressLine1,AddressLine2,ContactEmail,ContactNo,ValidTillDate,IsActive")] VendorMaster vendorMaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vendorMaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vendorMaster);
        }

        // GET: VendorMaster/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendorMaster = await _context.VendorMaster.FindAsync(id);
            if (vendorMaster == null)
            {
                return NotFound();
            }
            return View(vendorMaster);
        }

        // POST: VendorMaster/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("ID,Code,Name,AddressLine1,AddressLine2,ContactEmail,ContactNo,ValidTillDate,IsActive")] VendorMaster vendorMaster)
        {
            if (id != vendorMaster.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vendorMaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendorMasterExists(vendorMaster.ID))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vendorMaster);
        }

        private bool VendorMasterExists(long id)
        {
            return _context.VendorMaster.Any(e => e.ID == id);
        }

        // GET: VendorMaster/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendorMaster = await _context.VendorMaster.FirstOrDefaultAsync(m => m.ID == id);
            if (vendorMaster == null)
            {
                return NotFound();
            }

            return View(vendorMaster);
        }

        // POST: VendorMaster/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var vendorMaster = await _context.VendorMaster.FindAsync(id);
            if (vendorMaster == null)
            {
                return NotFound();
            }

            _context.VendorMaster.Remove(vendorMaster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
