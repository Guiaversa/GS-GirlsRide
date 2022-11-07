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
        Cartao cartao;
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

            if (cliente.Pagamentos.metodoPagamento == "Cartão")
            {
                if (cliente.CartaoId != 0)
                {
                    _context.Clientes.Add(cliente);
                    _context.SaveChanges();

                    TempData["msg"] = "Ride iniciada com sucesso!";
                    return RedirectToAction("Index2");
                }
                else
                {
                    TempData["msge"] = "Você precisa selecionar um Cartão";
                     return RedirectToAction("CadastrarCartao");
                }
            }
            else
            {
                cartao.CartaoId = 1;
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
                TempData["msg"] = "Ride iniciada com sucesso!";
                return RedirectToAction("Index2");
            }
            
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            var lista = _context.Carros.ToList();
            ViewBag.carrosList = new SelectList(lista, "CarroId", "ModeloCarro");

            var listaCartao = _context.Cartoes.ToList();
            ViewBag.cartoesList = new SelectList(listaCartao, "CartaoId", "nrCartao");

            return View();

        }

        [HttpPost]
        public IActionResult CadastrarCartao(Cartao cartao)
        {
            _context.Cartoes.Add(cartao);
            _context.SaveChanges();

            TempData["msgCartao"] = "Cartão cadastrado com sucesso!";

            return RedirectToAction("Cadastrar");
        }

        [HttpGet]
        public IActionResult CadastrarCartao()
        {
            
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

        public IActionResult IndexCartoes()
        {
            var lista = _context.Clientes.Include(ca => ca.Cartoes).ToList();

            return View(lista);
        }


        [HttpPost]
        public IActionResult RemoverCt(int id)
        {
            var RemoverCartao = _context.Cartoes.Find(id);
            _context.Cartoes.Remove(RemoverCartao);
            _context.SaveChanges();

            TempData["msgcr"] = "Cartão removido!";

            return RedirectToAction("IndexCartoes");
        }
    }
}
