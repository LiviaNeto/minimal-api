using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Interfaces;
using MinimalApi.DTOs;

namespace Test.Mocks;

public class VeiculoServicoMock  : IVeiculoServico
{
    private static List<Veiculo> veiculos = new List<Veiculo>(){
        new Veiculo{
            Id = 1,
            Nome = "Fusca",
            Marca = "Volkswagen",
            Ano = 1980
        },
        new Veiculo{
            Id = 2,
            Nome = "Civic",
            Marca = "Honda",
            Ano = 2020
        }
    };

    public Veiculo? BuscaPorId(int id)
    {
        return veiculos.Find(v => v.Id == id);
    }

    public void Incluir(Veiculo veiculo)
    {
        veiculos.Add(veiculo);
    }

    public void Atualizar(Veiculo veiculo)
    {
        var existingVeiculo = veiculos.FirstOrDefault(v => v.Id == veiculo.Id);
        if (existingVeiculo != null)
        {
            existingVeiculo.Nome = veiculo.Nome;
            existingVeiculo.Marca = veiculo.Marca;
            existingVeiculo.Ano = veiculo.Ano;
        }
    }

    public void Apagar(Veiculo veiculo)
    {
        veiculos.Remove(veiculo);
    }

    public List<Veiculo> Todos(int? pagina = 1, string? nome = null, string? marca = null)
    {
        return veiculos;
    }
}