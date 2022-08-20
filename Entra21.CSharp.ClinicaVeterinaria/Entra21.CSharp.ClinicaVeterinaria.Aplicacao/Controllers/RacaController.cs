using Entra21.CSharp.ClinicaVeterinaria.Repositorio.BancoDados;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Enuns;
using Entra21.CSharp.ClinicaVeterinaria.Servico;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.ClinicaVeterinaria.Aplicacao.Controllers
{
    // Dois pontos Herança(mais pra frente)
    public class RacaController : Controller
    {
        private readonly IRacaServico _racaServico;

        //Construtor: objetivo construir o objeto de RacaController, com o mínimo necessário para o funiconamento correto.
        public RacaController(ClinicaVeterinariaContexto contexto)
        {
            _racaServico = new RacaServico(contexto);
        }

        /// <summary>
        /// Endpoint que permite listar todas as raças
        /// </summary>
        /// <returns>Retorna a página html com as raças</returns>
      
        [HttpGet("/raca")]

        public IActionResult ObterTodos()
        {
            var racas = _racaServico.ObterTodos();

            // Passar informação do C# para o HTML
            ViewBag.Racas = racas;

            return View("Index");
        }

        [HttpGet("/raca/cadastrar")]

        public IActionResult Cadastrar()
        {
            var especies = ObterEspecies();

            ViewBag.Especies = especies;

            var racaCadastrarViewModel = new RacaCadastrarViewModels();

            return View(racaCadastrarViewModel);
        }

        [HttpPost("/raca/cadastrar")]
        public IActionResult Cadastrar(
            [FromForm] RacaCadastrarViewModels racaCadastrarViewModels)
        {
            // Valida o parâmetro recebido na Action se é invalido
            if (!ModelState.IsValid)
            {
                ViewBag.Especies = ObterEspecies();             

                return View(racaCadastrarViewModels);
            }
            _racaServico.Cadastrar(racaCadastrarViewModels);

            return RedirectToAction("Index");
        }

        [HttpGet("/raca/apagar")]
        // https://localhost:porta/raca/apagar?id=4
        public IActionResult Apagar([FromQuery] int id)
        {
            _racaServico.Apagar(id);

            return RedirectToAction("Index");
        }

        [HttpGet("/raca/editar")]

        public IActionResult Editar([FromQuery] int id)
        {
            var raca = _racaServico.ObterPorId(id);
            List<string> especies = ObterEspecies();

            ViewBag.Raca = raca;
            ViewBag.Especies = especies;

            return View("Editar");
        }
                
        [HttpPost("/raca/editar")]

        public IActionResult Editar(
            [FromForm] RacaEditarViewModels racaEditarViewModels)
        {
            _racaServico.Editar(racaEditarViewModels);

            return RedirectToAction("Index");
        }

        private List<string> ObterEspecies()
        {
            return Enum.GetNames<Especie>()
                .OrderBy(x => x)
                .ToList();
        }
    }
}
