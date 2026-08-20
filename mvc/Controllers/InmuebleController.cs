using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using mvc.Models;

namespace mvc.Controllers
{
    public class InmuebleController : Controller
    {
        private readonly AppDbContext _context;

        public InmuebleController(AppDbContext context)
        {
            _context = context;
        }

        // LISTAR INMUEBLES

        public async Task<IActionResult> Index()
        {
            var inmuebles = await _context.Inmuebles
                .Include(i => i.Propietario)
                .ToListAsync();

            return View(inmuebles);
        }


        // CREAR INMUEBLE

        // Muestra el formulario
        public async Task<IActionResult> Create()
        {
            await CargarPropietarios();

            return View();
        }

        // Recibe los datos del formulario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Inmueble inmueble)
        {
            if (ModelState.IsValid)
            {
                _context.Inmuebles.Add(inmueble);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            await CargarPropietarios();

            return View(inmueble);
        }


        // Carga los propietarios para el desplegable
        private async Task CargarPropietarios()
        {
            var propietarios = await _context.Propietarios
                .OrderBy(p => p.Apellido)
                .ThenBy(p => p.Nombre)
                .ToListAsync();

            ViewBag.Propietarios = new SelectList(
                propietarios,
                "Id",
                "Apellido"
            );
        }
    }
}