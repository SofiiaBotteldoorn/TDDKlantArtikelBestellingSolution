using TDDKlantArtikelBestelling;

namespace TDDKlantArtikelBestellingTest;

[TestClass]
public class ArtikelTest
{
    [DataTestMethod]
    [DataRow("", "4,5", "21,0")]    //Artikel met lege naam is niet ok
    [DataRow("  ", "4,5", "21,0")]  //Artikel met enkel spaties is niet ok
    [DataRow(null, "4,5", "21,0")]  //Artikel met naam = null
    [DataRow("Artikel MT-305", "-10,3", "21,0")]    //Artikel met negatief prijs is niet ok
    [DataRow("Artikel MT-315", "0,00", "21,0")]     //Artikel met 0 prijs is niet ok
    [DataRow("Artikel BFG-300", "12,3", "100,1")]   //Artikel met te hoog btw percentage
    [DataRow("Artikel SCP-180", "12,5", "0")]   //Artikel met te laag btw percentage
    [TestMethod]
    public void VerkeerdeArtikels(string naam, string prijsExclBtw, string btwPercentage)
    {
        //Arrange
        //Act
        //Assert
        Assert.ThrowsException<ArgumentException>(() => new Artikel(naam, decimal.Parse(prijsExclBtw), decimal.Parse(btwPercentage)));
    }
    [DataTestMethod]
    [DataRow("SCP-180", "0,1", "21,0")]     //Artikel met laagste prijs
    [DataRow("SCP-175", "15,5", "0,01")]    //Atikel met laagste btw
    [DataRow("SCP-387", "15,5", "100,0")]   //Artikel met hoogste btw
    [DataRow("SCP-389", "10,3", "21,0")]    //Artikel met correcte waarden
    [TestMethod]
    public void CorrecteArtikels(string naam, string prijsExclBtw, string btwPercentage)
    {
        //Arrange
        //Act
        //Assert
        new Artikel(naam, decimal.Parse(prijsExclBtw), decimal.Parse(btwPercentage));
    }
    [TestMethod]
    public void PrijsInclusiefBtw_PrijsExclBtw15enBtwPercentage21_Is18Punt15()
    {
        //Arrange
        var artikel = new Artikel("SCP-300", decimal.Parse("15"), decimal.Parse("21,0"));
        //Act
        //Assert
        Assert.AreEqual(18.15m, artikel.PrijsInclusiefBtw());
    }
}