using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels.Racas;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico
{
    public interface IRacaServico
    {
        void Cadastrar(RacaCadastrarViewModels racaCadastrarViewModels);
        List<Raca> ObterTodos();
        void Editar(RacaEditarViewModels racaEditarViewModels);
        void Apagar(int id);
        Raca ObterPorId(int id);
    }
}
