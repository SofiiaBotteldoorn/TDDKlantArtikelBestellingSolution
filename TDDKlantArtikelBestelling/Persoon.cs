namespace TDDKlantArtikelBestelling
{
    public class Persoon
    {
        private List<string> namen = new List<string>();
        public Persoon(string familienaam)
        {
            if (string.IsNullOrWhiteSpace(familienaam))
            {
                throw new ArgumentException(nameof(familienaam), "Familienaam mag niet leeg of null zijn!");
            }

            if (!IsGeldigeNaam(familienaam))
            {
                throw new ArgumentException(nameof(familienaam), "Ongeldige familienaam!");
            }
            this.familienaam = familienaam.Trim();
        }
        public void AddNaam(string naam)
        {

            if (string.IsNullOrWhiteSpace(naam))
            {
                throw new ArgumentException(nameof(naam), "Naam mag niet leeg of null zijn!");
            }
            var naamZonderSpaties = naam.Trim();
            if (!IsGeldigeNaam(naamZonderSpaties))
            {
                throw new ArgumentException(nameof(naamZonderSpaties), "Ongeldige naam!");
            }
            if (namen.Any(n => n.Equals(naam, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException(nameof(naamZonderSpaties), "Deze naam is al toegevoegd!");
            }
            namen.Add(naamZonderSpaties);
        }
        private string familienaam;
        public string Familienaam => familienaam;
        private bool IsGeldigeNaam(string naam)
        {
            return naam.All(c => char.IsLetter(c) || c == '-');
        }

        public override string ToString()
        {
            return string.Join(" ", namen);
        }
    }
}
