using MinimalApi.Dominio.Servicos;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Infraestrutura.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Test.Domain.Servicos;

[TestClass]
public class VeiculoServicoTest
{
    private DbContexto CriarContextoDeTeste()
    {
        var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var path = Path.GetFullPath(Path.Combine(assemblyPath ?? "", "..", "..", ".."));

        var builder = new ConfigurationBuilder()
            .SetBasePath(path ?? Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();
        
        var configuration = builder.Build();        
        
        return new DbContexto(configuration);
    }

    [TestMethod]
    public void TestandoIncluirVeiculo()
    {
        // Arrange
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE veiculos");  // Limpar a tabela de veículos para o teste

        var veiculo = new Veiculo
        {
            Nome = "Fusca",
            Marca = "Volkswagen",
            Ano = 1980
        };
        
        var veiculoServico = new VeiculoServico(context);

        // Act
        veiculoServico.Incluir(veiculo);

        // Assert
        var veiculos = veiculoServico.Todos(1); // Buscando o primeiro veículo
        Assert.AreEqual(1, veiculos.Count);
        Assert.AreEqual("Fusca", veiculos.First().Nome);
    }

    [TestMethod]
    public void TestandoBuscaPorIdVeiculo()
    {
        // Arrange
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE veiculos");  // Limpar a tabela de veículos para o teste

        var veiculo = new Veiculo
        {
            Nome = "Fusca",
            Marca = "Volkswagen",
            Ano = 1980
        };
        
        var veiculoServico = new VeiculoServico(context);
        veiculoServico.Incluir(veiculo);  // Adiciona o veículo

        // Act
        var veiculoDoBanco = veiculoServico.BuscaPorId(veiculo.Id);

        // Assert
        Assert.IsNotNull(veiculoDoBanco);
        Assert.AreEqual(veiculo.Id, veiculoDoBanco?.Id);
        Assert.AreEqual(veiculo.Nome, veiculoDoBanco?.Nome);
    }

    [TestMethod]
    public void TestandoBuscarTodosVeiculos()
    {
        // Arrange
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE veiculos");

        var veiculo1 = new Veiculo
        {
            Nome = "Fusca",
            Marca = "Volkswagen",
            Ano = 1980
        };
        var veiculo2 = new Veiculo
        {
            Nome = "Civic",
            Marca = "Honda",
            Ano = 2020
        };
        
        var veiculoServico = new VeiculoServico(context);
        veiculoServico.Incluir(veiculo1);
        veiculoServico.Incluir(veiculo2);

        // Act
        var veiculos = veiculoServico.Todos(1); // Paginação de 10 veículos, então apenas 2 devem ser retornados

        // Assert
        Assert.AreEqual(2, veiculos.Count);  // Deve retornar 2 veículos
        Assert.IsTrue(veiculos.Any(v => v.Nome == "Fusca"));
        Assert.IsTrue(veiculos.Any(v => v.Nome == "Civic"));
    }

    [TestMethod]
    public void TestandoAtualizarVeiculo()
    {
        // Arrange
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE veiculos");

        var veiculo = new Veiculo
        {
            Nome = "Fusca",
            Marca = "Volkswagen",
            Ano = 1980
        };

        var veiculoServico = new VeiculoServico(context);
        veiculoServico.Incluir(veiculo);

        // Act
        veiculo.Nome = "Fusca Atualizado";
        veiculo.Marca = "Volkswagen Atualizado";
        veiculoServico.Atualizar(veiculo);

        // Assert
        var veiculoAtualizado = veiculoServico.BuscaPorId(veiculo.Id);
        Assert.IsNotNull(veiculoAtualizado);
        Assert.AreEqual("Fusca Atualizado", veiculoAtualizado?.Nome);
        Assert.AreEqual("Volkswagen Atualizado", veiculoAtualizado?.Marca);
    }

    [TestMethod]
    public void TestandoApagarVeiculo()
    {
        // Arrange
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE veiculos");

        var veiculo = new Veiculo
        {
            Nome = "Fusca",
            Marca = "Volkswagen",
            Ano = 1980
        };
        
        var veiculoServico = new VeiculoServico(context);
        veiculoServico.Incluir(veiculo);

        // Act
        veiculoServico.Apagar(veiculo);

        // Assert
        var veiculoDoBanco = veiculoServico.BuscaPorId(veiculo.Id);
        Assert.IsNull(veiculoDoBanco);  // O veículo foi removido, então deve ser null
    }
}
