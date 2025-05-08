using TDDKlantArtikelBestelling;

namespace TDDKlantArtikelBestellingTest;

[TestClass]
public class KlantTest
{
    [TestMethod]
    public void KlantId_NegatieveId_Fout()
    {
        //Arrange
        //Act
        //Assert
        Assert.ThrowsException<ArgumentException>(() => new Klant(new List<string> { "Anna", "Maria" }, "Familienaam", -1, "email@google.com"));
    }
    [TestMethod]
    public void KlantId_0Id_Fout()
    {
        //Arrange
        //Act
        //Assert
        Assert.ThrowsException<ArgumentException>(() => new Klant(new List<string> { "Anna", "Maria" }, "Familienaam", 0, "email@google.com"));
    }
    [DataTestMethod]
    [DataRow("annamaria.be")]   //Ontbreekt @
    [DataRow("@domein.com")]    //Ontbreekt lokale naam
    [DataRow("annamaria@")]     //Ontbreekt domein
    [DataRow("annamaria@domein")] //Ontbreekt punt
    [DataRow("annamaria@domein.")]  //Punt zonder subdomein
    [DataRow("annamaria@.be")]          //Ontbreekt hoofddomein
    [DataRow("annamaria@.")]            //Ontbreekt hoofd- en subdomein
    public void Email_IsOngeldig_ThrowsException(string foutiveEmail)
    {
        //Arrange
        //Act
        //Assert
        Assert.ThrowsException<ArgumentException>(() => new Klant(new List<string> { "Anna", "Maria" }, "Janssens", 12, foutiveEmail));
    }
    [DataTestMethod]
    [DataRow("anna-maria@gmail.be")]
    [DataRow("annamaria@domein.com")]
    [DataRow("annamaria1503@outlook.nl")]
    public void CorrecteKlant(string correcteEmail)
    {
        //Arrage
        var klant = new Klant(new List<string> { "Anna", "Maria" }, "Janssens", 1, correcteEmail);
        //Act
        //Assert
        Assert.AreEqual("Janssens", klant.Familienaam);
        Assert.AreEqual(1, klant.KlantId);
        Assert.AreEqual(correcteEmail, klant.Email);
    }
}
