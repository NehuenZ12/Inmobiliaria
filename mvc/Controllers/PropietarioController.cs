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

        // GET: /Propietario
        public async Task<IActionResult> Index()
        {
            var propietarios = await _context.Propietarios.ToListAsync();

            return View(propietarios);
        }
    }
}