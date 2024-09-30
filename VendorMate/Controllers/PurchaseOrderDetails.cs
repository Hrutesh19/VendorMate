using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VendorMate.Models;
using System.Threading.Tasks;
using YourNamespace.Models;

namespace VendorMate.Controllers
{
    public class PurchaseOrderDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PurchaseOrderDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PurchaseOrderDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.PurchaseOrderDetails.ToListAsync());
        }

        // GET: PurchaseOrderDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PurchaseOrderDetails/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,OrderID,MaterialID,ItemQuantity,ItemRate,ItemNotes,ExpectedDate")] PurchaseOrderDetails purchaseOrderDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(purchaseOrderDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(purchaseOrderDetails);
        }

        // GET: PurchaseOrderDetails/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseOrderDetails = await _context.PurchaseOrderDetails.FindAsync(id);
            if (purchaseOrderDetails == null)
            {
                return NotFound();
            }
            return View(purchaseOrderDetails);
        }

        // POST: PurchaseOrderDetails/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("ID,OrderID,MaterialID,ItemQuantity,ItemRate,ItemNotes,ExpectedDate")] PurchaseOrderDetails purchaseOrderDetails)
        {
            if (id != purchaseOrderDetails.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchaseOrderDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaseOrderDetailsExists(purchaseOrderDetails.ID))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(purchaseOrderDetails);
        }

        // GET: PurchaseOrderDetails/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseOrderDetails = await _context.PurchaseOrderDetails.FirstOrDefaultAsync(m => m.ID == id);
            if (purchaseOrderDetails == null)
            {
                return NotFound();
            }

            return View(purchaseOrderDetails);
        }

        // POST: PurchaseOrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var purchaseOrderDetails = await _context.PurchaseOrderDetails.FindAsync(id);
            if (purchaseOrderDetails == null)
            {
                return NotFound();
            }

            _context.PurchaseOrderDetails.Remove(purchaseOrderDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurchaseOrderDetailsExists(long id)
        {
            return _context.PurchaseOrderDetails.Any(e => e.ID == id);
        }
    }
}
