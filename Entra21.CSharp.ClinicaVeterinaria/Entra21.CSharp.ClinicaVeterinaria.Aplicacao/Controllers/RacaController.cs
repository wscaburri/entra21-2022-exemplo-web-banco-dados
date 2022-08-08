﻿using Entra21.CSharp.ClinicaVeterinaria.Servico;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.ClinicaVeterinaria.Aplicacao.Controllers
{
    // Dois pontos Herança(mais pra frente)
    public class RacaController : Controller
    {
        private RacaServico racaServico;

        //Construtor: objetivo construir o objeto de RacaController, com o mínimo necessário para o funiconamento correto.
        public RacaController()
        {
            racaServico = new RacaServico();
        }

        /// <summary>
        /// Endpoint que permite listar todas as raças
        /// </summary>
        /// <returns>Retorna a página html com as raças</returns>
        [Route("/raca")]
        [HttpGet]

        public IActionResult ObterTodos()
        {
            return View("Index");
        }

        [Route("/raca/cadastrar")]
        [HttpGet]

        public IActionResult Cadastrar()
        {
            return View();
        }

        [Route("/raca/registrar")]
        [HttpGet]
        public IActionResult Registrar(
            [FromQuery] string nome,
            [FromQuery] string especie)
        {
            racaServico.Cadastrar(nome, especie);

            return RedirectToAction("Index");
        }
    }
}