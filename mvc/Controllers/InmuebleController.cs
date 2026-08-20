using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc.Models;

namespace mvc.Controllers
{
    public class InmuebleController : Controller
    {
        private readonly AppDbContext _context;

        // Constructor
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
    }
}