using TDDKlantArtikelBestelling;

namespace TDDKlantArtikelBestellingTest;

[TestClass]
public class BestellingTest
{
    private Bestelling bestelling = new Bestelling();
    [TestInitialize]
    public void Initialize()
    {
        bestelling = new Bestelling();
    }
    [TestMethod]
    public void AddArtikel_NullToevoegen_IsFout()
    {
        //Arrange
        //Act
        //Assert
        Assert.ThrowsException<ArgumentException>(() => bestelling.AddArtikel(null!));
    }
    [TestMethod]
    public void AddArtikel_TweeKeerZelfdeArtikel_IsToegestaanEnAantalIsTwee()
    {
        //Arrange
        var artikel = new Artikel("SCP-180", 0.1m, 21.0m);

        //Act
        bestelling.AddArtikel(artikel);
        bestelling.AddArtikel(artikel);
        //Assert
        Assert.AreEqual(2, bestelling.AantalArtikels);
    }
    [TestMethod]
    public void NewBestelling_GeenArtikels()
    {
        //Arrange
        //Act
        //Assert
        Assert.AreEqual(0, bestelling.AantalArtikels);
        Assert.AreEqual(0m, bestelling.TotaalTeBetalen);
    }
    [TestMethod]
    public void AantalArtikels_EenArtikelToevoegen_AantalVergroten()
    {
        //Arrange
        var artikel = new Artikel("SCP-180", 0.1m, 21.0m);
        //Act
        bestelling.AddArtikel(artikel);
        //Assert
        Assert.AreEqual(1, bestelling.AantalArtikels);
    }
    [TestMethod]
    public void TotaalTeBetalen_EenArtikelToevoegen_TotaalVergroten()
    {
        //Arrange
        var artikel = new Artikel("SCP-300", 10.0m, 21.0m);
        //Act
        bestelling.AddArtikel(artikel);
        //Assert
        Assert.AreEqual(12.10m, bestelling.TotaalTeBetalen);
    }
    [TestMethod]
    public void TotaalTeBetalen_TweeArtikelsToevoegen_TotaalVergroten()
    {
        //Arrange
        //Act
        bestelling.AddArtikel(new Artikel("SCP-145", 10.0m, 21.0m));
        bestelling.AddArtikel(new Artikel("SCP-027", 18.0m, 21.0m));
        //Assert
        Assert.AreEqual(33.88m, bestelling.TotaalTeBetalen);
    }
}
