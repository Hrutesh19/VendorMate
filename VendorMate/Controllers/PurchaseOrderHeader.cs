namespace VendorMate.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;
    using VendorMate.Models;
    using YourNamespace.Models;

    public class PurchaseOrderHeaderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PurchaseOrderHeaderController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PurchaseOrderHeader
        public async Task<IActionResult> Index()
        {
            return View(await _context.PurchaseOrderHeader.ToListAsync());
        }

        // GET: PurchaseOrderHeader/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PurchaseOrderHeader/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,OrderNumber,OrderDate,VendorID,Notes,OrderValue,OrderStatus")] PurchaseOrderHeader purchaseOrderHeader)
        {
            if (ModelState.IsValid)
            {
                _context.Add(purchaseOrderHeader);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(purchaseOrderHeader);
        }

        // GET: PurchaseOrderHeader/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseOrderHeader = await _context.PurchaseOrderHeader.FindAsync(id);
            if (purchaseOrderHeader == null)
            {
                return NotFound();
            }
            return View(purchaseOrderHeader);
        }

        // POST: PurchaseOrderHeader/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("ID,OrderNumber,OrderDate,VendorID,Notes,OrderValue,OrderStatus")] Models.PurchaseOrderHeader purchaseOrderHeader)
        {
            if (id != purchaseOrderHeader.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchaseOrderHeader);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaseOrderHeaderExists(purchaseOrderHeader.ID))
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
            return View(purchaseOrderHeader);
        }

        private bool PurchaseOrderHeaderExists(long id)
        {
            return _context.PurchaseOrderHeader.Any(e => e.ID == id);
        }

        // GET: PurchaseOrderHeader/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseOrderHeader = await _context.PurchaseOrderHeader
                .FirstOrDefaultAsync(m => m.ID == id);
            if (purchaseOrderHeader == null)
            {
                return NotFound();
            }

            return View(purchaseOrderHeader);
        }


        [HttpPost, ActionName("Delete")]  // ActionName matches the Delete view form action
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var purchaseOrderHeader = await _context.PurchaseOrderHeader.FindAsync(id);
            if (purchaseOrderHeader == null)
            {
                return NotFound();
            }

            _context.PurchaseOrderHeader.Remove(purchaseOrderHeader);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
