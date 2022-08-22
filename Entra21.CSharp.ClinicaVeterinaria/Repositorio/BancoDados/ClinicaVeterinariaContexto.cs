using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Mapeamentos;
using Microsoft.EntityFrameworkCore;

namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.BancoDados
{
    public class ClinicaVeterinariaContexto : DbContext
    {
        public DbSet<Raca> Racas { get; set; }

        public ClinicaVeterinariaContexto(
            DbContextOptions<ClinicaVeterinariaContexto> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Documentação: https://docs.microsoft.com/pt-br/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli
            // Necessário instalar a ferramenta do dotnet of core
            //  dotnet tool install --global dotnet-ef
            // 1ª Etapa - Criar a entidade Raca.cs
            // 2ª Etapa - Criar o mapeamento da entidade para tabela RacaMapeamento.cs
            // 3ª Etapa - Registrar o mapeamento no próprio Contexto
            // 4ª Etapa - Gerar a migration  
            //  dotnet of migrations add NomeMigration
            // dotnet ef migrations add AdicionarRacaTabela --project Repositorio --startup-project Entra21.CSharp.ClinicaVeterinaria.Aplicacao
            // 5ª Etapa - A migration poderá ser aplicada de duas formas:
            //      -Executar comando para aplicar a migration sem a necessidade de executar a aplicação dotnet ef database update
            //      -Executar a aplicação irá aplicar a migration

            modelBuilder.ApplyConfiguration(new RacaMapeamento());
        }
    }
}
