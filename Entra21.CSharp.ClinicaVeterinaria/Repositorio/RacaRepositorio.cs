using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;

namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio
{
    public class RacaRepositorio : IRacaRepositorio
    {       
        public void Cadastrar(Raca raca)
        {
            Console.WriteLine($"Rep: Nome: {raca.Nome} Espécie: {raca.Especie}");
        }
    }
}
