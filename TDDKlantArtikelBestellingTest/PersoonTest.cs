using TDDKlantArtikelBestelling;

namespace TDDKlantArtikelBestellingTest;

[TestClass]
public class PersoonTest
{
    private Persoon persoon = null!;

    [TestInitialize]
    public void Initialize()
    {
        persoon = new Persoon("eenFamilienaam");
    }
    [DataTestMethod]
    [DataRow("")]//Leeg naam is fout
    [DataRow(null)]//Null naam is fout
    [DataRow("  ")]//Alleen spaties als naam is fout
    [DataRow("7$.*<>%@#:=+!")]
    [TestMethod]
    public void AddNaam_FotieveNaam_ThrowsArgumentException(string foutieveNaam)
    {
        //Arrange
        //Act
        //Assert
        Assert.ThrowsException<ArgumentException>(() => persoon.AddNaam(foutieveNaam));
    }
    [TestMethod]
    public void AddNaam_NullWaardeInVerzameling_ThrowsException()
    {
        //Arrange
        //Act
        //Assert
        Assert.ThrowsException<ArgumentException>(() => persoon.AddNaam(null!));
    }
    [TestMethod]
    public void AddNaam_GeldigeNaamToevoegen_IsOk()
    {
        //Arrange
        //Act
        persoon.AddNaam("Maria");
        //Assert
        Assert.AreEqual("Maria", persoon.ToString());
    }
    [TestMethod]
    public void AddNaam_NaamMetKoppelteken_IsOk()
    {
        //Arrange
        //Act
        persoon.AddNaam("Hyun-woo");
        //Assert
        Assert.AreEqual("Hyun-woo", persoon.ToString());
    }
    [TestMethod]
    public void AddNaam_TweeKeerDezelfdeNaam_ThrowsArgumentException()
    {
        //Arrange
        //Act
        persoon.AddNaam("Michael");
        //Assert
        Assert.ThrowsException<ArgumentException>(() => persoon.AddNaam("Michael"));
    }
    [TestMethod]
    public void AddNaam_TweeKeerZelfdeNaamMetVerschillendeCase_IsNietOk()
    {
        //Arrange
        //Act
        persoon.AddNaam("Eva");
        //Assert
        Assert.ThrowsException<ArgumentException>(() => persoon.AddNaam("eva"));
    }
    [TestMethod]
    public void NewPersoon_GeenVoornamen()
    {
        //Arrange
        //Act
        //Assert
        Assert.AreEqual("", persoon.ToString());
    }
    [TestMethod]
    public void ToString_MetTweeNamen_GeeftTweeNamenMetSpatie()
    {
        // Arrange
        // Act
        persoon.AddNaam("Pieter");
        persoon.AddNaam("Jan");
        string alleVoornamen = persoon.ToString();

        // Assert
        Assert.AreEqual("Pieter Jan", alleVoornamen);
    }
    [TestMethod]
    public void AddNaam_NaamMetSpatiesWordtGetrimd()
    {
        //Arrange
        //Act
        persoon.AddNaam(" Sofiia ");
        //Assert
        Assert.AreEqual("Sofiia", persoon.ToString());
    }
    [DataTestMethod]
    [DataRow("")]//Leeg naam is fout
    [DataRow(null)]//Null naam is fout
    [DataRow("  ")]//Alleen spaties als naam is fout
    [DataRow("7$.*<>%@#:=+!")]//Ongeldige symbolen
    [TestMethod]
    public void VerkeerdeFamilienaam(string foutFamilienaam)
    {
        //Arrange
        //Act
        //Assert
        Assert.ThrowsException<ArgumentException>(() => new Persoon(foutFamilienaam));
    }
}
