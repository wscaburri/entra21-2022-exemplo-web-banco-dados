using Entra21.CSharp.ClinicaVeterinaria.Repositorio;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.BancoDados;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico
{
    // A classe RacaServico irá implementar a interface IRacaServico, ou seja, deverá honrar as cláusulas definidas na interface(contrato).
    public class RacaServico : IRacaServico
    {
        private IRacaRepositorio _racaRepositorio;

        // Construtor: Construir o objeto de RacaServico com o mínimo para a correta execução.
        public RacaServico(ClinicaVeterinariaContexto contexto)
        {
            _racaRepositorio = new RacaRepositorio(contexto);
        }

        public void Editar(RacaEditarViewModels racaEditarViewModels)
        {
            var raca = new Raca();
            raca.Id = racaEditarViewModels.Id;
            raca.Nome = racaEditarViewModels.Nome.Trim();
            raca.Especie = racaEditarViewModels.Especie;

            _racaRepositorio.Atualizar(raca);
        }

        public void Apagar(int id)
        {
            _racaRepositorio.Apagar(id);
        }

        public void Cadastrar(RacaCadastrarViewModels racaCadastrarViewModels)
        {
            var raca = new Raca();
            raca.Nome = racaCadastrarViewModels.Nome;
            raca.Especie = racaCadastrarViewModels.Especie;

            _racaRepositorio.Cadastrar(raca);
        }

        public Raca ObterPorId(int id)
        {
            var raca = _racaRepositorio.ObterPorId(id);

            return raca;
        }

        public List<Raca> ObterTodos()
        {
            var racasDoBanco = _racaRepositorio.ObterTodos();

            return racasDoBanco;
        }
    }
}
