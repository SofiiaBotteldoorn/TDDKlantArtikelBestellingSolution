namespace TDDKlantArtikelBestelling
{
    public class Artikel
    {

        private decimal prijsExclBtw;
        private decimal btwPercentage;
        public Artikel(string naam, decimal prijsExclBtw, decimal btwPercentage)
        {
            if (string.IsNullOrWhiteSpace(naam))
            {
                throw new ArgumentException(nameof(naam), "Artikelnaam kan niet leeg of null zijn!");
            }
            if (prijsExclBtw <= 0m)
                throw new ArgumentException(nameof(prijsExclBtw), "Artikelprijs zonder btw moet positief zijn!");
            if (btwPercentage <= 0m || btwPercentage > 100.0m)
            {
                throw new ArgumentException(nameof(btwPercentage), "Het btwpercentage moet tussen 0,01 en 100 liggen!");
            }

            this.naam = naam;
            this.prijsExclBtw = prijsExclBtw;
            this.btwPercentage = btwPercentage;
        }
        private string naam;
        public string Naam => naam;
        public decimal PrijsExclBtw => prijsExclBtw;
        public decimal BtwPercentage => btwPercentage;
        public decimal PrijsInclusiefBtw() => Math.Round(prijsExclBtw * (100 + btwPercentage) / 100, 2, MidpointRounding.AwayFromZero);
    }
}

