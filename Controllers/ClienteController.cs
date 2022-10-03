using Mantemiento_ClientesMVC.Data;
using Mantemiento_ClientesMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mantemiento_ClientesMVC.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ApplicationDbContext db;
        public ClienteController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Crear(int? id)
        {
            Cliente cliente = new Cliente();
            if (id == null)
            {
                return View(cliente);
            }
            else
            {
                cliente = await db.Cliente.FindAsync(id);
                return View(cliente);
            }
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                if(cliente.Id==0)//Crea el registro
                {
                    await db.Cliente.AddAsync(cliente);
                    await db.SaveChangesAsync();
                    return RedirectToAction(nameof(Crear));
                }
                else
                {
                    db.Cliente.Update(cliente);
                    await db.SaveChangesAsync();
                    return RedirectToAction(nameof(Crear), new { id = 0 });
                }
            }
               
            return View(cliente);
        }
        [HttpGet]
        public async Task<IActionResult> ObtenerClientes()
        {
            var clientes = await db.Cliente.ToListAsync();
            return Json(new {data = clientes});
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id) 
        {
            var clienteDb = await db.Cliente.FindAsync(id);
            if (clienteDb == null)
            {
                return Json(new { success = false, message = "Error al eliminar" });
            }
            db.Cliente.Remove(clienteDb);
            await db.SaveChangesAsync();
            return Json(new { succes = true, message = "Cliente eliminado exitosamente" });
        }
    }
}
