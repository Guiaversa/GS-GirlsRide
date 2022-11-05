using GrilsRide.Web.Models;
using GrilsRide.Web.Percistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GrilsRide.Web.Controllers
{
    public class ClienteController : Controller
    {
        private GirlsRideContext _context;

        public ClienteController(GirlsRideContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Remover(int id)
        {
            var clienteRemover = _context.Clientes.Find(id);
            _context.Clientes.Remove(clienteRemover);
            _context.SaveChanges();

            TempData["msg"] = "Ride cancelada!";

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Editar(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            _context.SaveChanges();

            TempData["msg"] = "Registro Atualizado!";

            return RedirectToAction("Index");

        }
 


        [HttpGet]
        public IActionResult Editar(int id)
        {
            var cliente = _context.Clientes.Find(id);

            return View(cliente);
        }

        [HttpPost]
        public IActionResult Cadastrar(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();

           

            if (cliente.Pagamentos.metodoPagamento == "Cartão")
            {
                return RedirectToAction("CadastrarCartao");
            }
            else
            {
                TempData["msg"] = "Ride iniciada com sucesso!";
                return RedirectToAction("Cadastrar");
            }

            
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            var lista = _context.Carros.ToList();
            ViewBag.carrosList = new SelectList(lista, "CarroId", "ModeloCarro");

            return View();

        }
        public IActionResult Index(string nome)
        {
            var lista = _context.Clientes.Where(c => c.Name.Contains(nome) || nome == null).Include(v => v.Carros).Include(p => p.Pagamentos)
                .ToList();

            return View(lista);
        }

        public IActionResult Index2(string nome)
        {
            var lista = _context.Clientes.Where(c => c.Name.Contains(nome) || nome == null).Include(v => v.Carros).Include(p => p.Pagamentos)
                .ToList();

            return View(lista);
        }
    }
}
