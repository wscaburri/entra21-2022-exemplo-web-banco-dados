﻿using Entra21.CSharp.ClinicaVeterinaria.Repositorio;
using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico
{
    // A classe RacaServico irá implementar a interface IRacaServico, ou seja, deverá honrar as cláusulas definidas na interface(contrato).
    public class RacaServico : IRacaServico
    {
        private RacaRepositorio racaRepositorio;

        public RacaServico()
        {
            racaRepositorio = new RacaRepositorio();
        }

        public void Cadastrar(string nome, string especie)
        {
            var raca = new Raca();
            raca.Nome = nome;
            raca.Especie = especie;

            racaRepositorio.Cadastrar(raca);

            Console.WriteLine($"Nome: {nome} Espécie: {especie}");
        }
    }
}
