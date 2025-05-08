namespace TDDKlantArtikelBestelling
{
    public class Bestelling
    {
        private Klant klant;
        private List<Artikel> bestelling = new List<Artikel>();
        public void AddArtikel(Artikel artikel)
        {
            if (artikel == null)
            {
                throw new ArgumentException(nameof(artikel), "Artikel mag niet null zijn.");
            }
            bestelling.Add(artikel);
        }
        public int AantalArtikels => bestelling.Count;
        public decimal TotaalTeBetalen => bestelling.Sum(artikel => artikel.PrijsInclusiefBtw());
    }
}
