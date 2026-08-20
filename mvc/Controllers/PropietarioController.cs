using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc.Models;

namespace mvc.Controllers
{
    public class PropietarioController : Controller
    {
        private readonly AppDbContext _context;

        public PropietarioController(AppDbContext context)
        {
            _context = context;
        }

        // Muestra todos los propietarios
        public async Task<IActionResult> Index()
        {
            var propietarios = await _context.Propietarios.ToListAsync();

            return View(propietarios);
        }

        // Muestra el formulario para crear un propietario
        public IActionResult Create()
        {
            return View();
        }

        // Recibe los datos del formulario y guarda el propietario
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
    }
}