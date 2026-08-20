using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc.Models;

namespace mvc.Controllers
{
    public class PropietarioController : Controller
    {
        private readonly AppDbContext _context;

        // Constructor: recibe la conexión a la base de datos
        public PropietarioController(AppDbContext context)
        {
            _context = context;
        }

        // LISTAR PROPIETARIOS

        public async Task<IActionResult> Index()
        {
            var propietarios = await _context.Propietarios.ToListAsync();

            return View(propietarios);
        }

        // CREAR PROPIETARIO
        // Muestra el formulario
        public IActionResult Create()
        {
            return View();
        }

        // Recibe los datos del formulario y los guarda
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Propietario propietario)
        {
            if (ModelState.IsValid)
            {
                _context.Propietarios.Add(propietario);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(propietario);
        }

        // EDITAR PROPIETARIO

        // Muestra el formulario con los datos actuales
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propietario = await _context.Propietarios.FindAsync(id);

            if (propietario == null)
            {
                return NotFound();
            }

            return View(propietario);
        }

        // Recibe los datos modificados y los guarda
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Propietario propietario)
        {
            if (id != propietario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(propietario);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(propietario);
        }

        // ELIMINAR PROPIETARIO

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var propietario = await _context.Propietarios.FindAsync(id);

            if (propietario == null)
            {
                return NotFound();
            }

            _context.Propietarios.Remove(propietario);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}