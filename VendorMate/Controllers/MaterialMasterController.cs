using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VendorMate.Models;
using System.Linq;
using System.Threading.Tasks;
using YourNamespace.Models;

namespace VendorMate.Controllers
{
    public class MaterialMasterController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MaterialMasterController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MaterialMaster
        public async Task<IActionResult> Index()
        {
            return View(await _context.MaterialMaster.ToListAsync());
        }

        // GET: MaterialMaster/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MaterialMaster/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Code,ShortText,LongText,Unit,ReorderLevel,MinOrderQuantity,IsActive")] MaterialMaster materialMaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(materialMaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(materialMaster);
        }

        // GET: MaterialMaster/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materialMaster = await _context.MaterialMaster.FindAsync(id);
            if (materialMaster == null)
            {
                return NotFound();
            }
            return View(materialMaster);
        }

        // POST: MaterialMaster/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("ID,Code,ShortText,LongText,Unit,ReorderLevel,MinOrderQuantity,IsActive")] MaterialMaster materialMaster)
        {
            if (id != materialMaster.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(materialMaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaterialMasterExists(materialMaster.ID))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(materialMaster);
        }

        private bool MaterialMasterExists(long id)
        {
            return _context.MaterialMaster.Any(e => e.ID == id);
        }

        // GET: MaterialMaster/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materialMaster = await _context.MaterialMaster
                .FirstOrDefaultAsync(m => m.ID == id);
            if (materialMaster == null)
            {
                return NotFound();
            }

            return View(materialMaster);
        }

        // POST: MaterialMaster/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var materialMaster = await _context.MaterialMaster.FindAsync(id);
            if (materialMaster == null)
            {
                return NotFound();
            }

            _context.MaterialMaster.Remove(materialMaster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
