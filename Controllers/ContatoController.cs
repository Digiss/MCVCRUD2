using MCVCRUD2.Models;
using MCVCRUD2.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCVCRUD2.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio contatoRepositorio1;

        public ContatoController(IContatoRepositorio contatoRepositorio) 
        {
            contatoRepositorio1 = contatoRepositorio;
        }
        public IActionResult Index()
        {
            List<ContatoModel> contatos = contatoRepositorio1.BuscarTodos();
            return View(contatos);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
            ContatoModel contato = contatoRepositorio1.ListarPorId(id);
            return View(contato);
        }
        public IActionResult Apagar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            contatoRepositorio1.Adicionar(contato);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            contatoRepositorio1.Atualizar(contato);
            return RedirectToAction("Index");
        }

    }
}
