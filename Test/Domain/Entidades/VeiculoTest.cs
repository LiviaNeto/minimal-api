using MinimalApi.Dominio.Entidades;

namespace Test.Domain.Entidades;

[TestClass]
public class VeiculoTest
{
    [TestMethod]
    public void TestarGetSetPropriedades()
    {
        //Arrange
        var veiculo = new Veiculo();

        //Act
        veiculo.Id = 1;
        veiculo.Nome = "teste";
        veiculo.Marca = "marcateste";
        veiculo.Ano = 2020;

        //Assert
        Assert.AreEqual(1, veiculo.Id);
        Assert.AreEqual("teste", veiculo.Nome);
        Assert.AreEqual("marcateste", veiculo.Marca);
        Assert.AreEqual(2020, veiculo.Ano);
    }
}
