using LojaVirtual.Libraries.Email;
using LojaVirtual.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LojaVirtual.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Contato()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult Contato(Contato contato)
        {
            try
            {
                var listaMensagens = new List<ValidationResult>();
                var contexto = new ValidationContext(contato);
                var isValid = Validator.TryValidateObject(contato, contexto, listaMensagens, true);

                if (isValid)
                {
                    Email.EnviarEmail(contato);
                    ViewData["MSG_S"] = "Email enviado com sucesso!";
                }
                else
                {

                    
                    StringBuilder sb = new StringBuilder();
                    foreach (var texto in listaMensagens)
                        sb.Append(texto.ErrorMessage + "<br />");

                    ViewData["MSG_E"] = sb.ToString();
                    ViewData["CONTATO"] = contato;

                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewData["MSG_E"] = "Erro ao enviar o Email!";
            }
            return View(contato);
        }

        public IActionResult CarrinhoCompras()
        {
            return View();
        }

        public IActionResult CadastroCliente()
        {

            return View();
        }
    }
}
