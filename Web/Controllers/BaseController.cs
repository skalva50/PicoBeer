using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PicoBeer.Domain;
using PicoBeer.Services;

namespace PicoBeer.Web.Controllers
{
    public class BaseController<T> : Controller where T : BaseEntity
    {
        private IService<T> _service;

        public BaseController(IService<T> service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.ListAllAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var test = await _service.GetByIdAsync(id.Value);
            if (test == null)
            {
                return NotFound();
            }

            return View(test);
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: Test/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(T entity)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(entity);
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        // GET: Test/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var test = await _service.GetByIdAsync(id.Value);
            if (test == null)
            {
                return NotFound();
            }
            return View(test);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, T entity)
        {
            if (id != entity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.UpdateAsync(entity);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntityExists(entity.Id))
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
            return View(entity);
        }

        // GET: Test/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var test = await _service.GetByIdAsync(id.Value);
            if (test == null)
            {
                return NotFound();
            }

            return View(test);
        }

        // POST: Test/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var test = await _service.GetByIdAsync(id);
            await _service.DeleteAsync(test);
            return RedirectToAction(nameof(Index));
        }

        private bool EntityExists(int id)
        {
            return _service.GetById(id) != null;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}