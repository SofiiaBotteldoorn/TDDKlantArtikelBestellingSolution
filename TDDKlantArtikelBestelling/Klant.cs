using System.Text.RegularExpressions;

namespace TDDKlantArtikelBestelling
{
    public class Klant : Persoon
    {
        private static readonly Regex regex = new Regex("^.+@.+\\..+$");
        private int klantId;
        private string email;
        public Klant(List<string> namen, string familienaam, int klantId, string email)
            : base(familienaam)
        {
            if (klantId <= 0)
            {
                throw new ArgumentException(nameof(klantId), "klantId moet positief zijn!");
            }
            if (!regex.IsMatch(email))
            {
                throw new ArgumentException(nameof(email), "Ongeldig email!");
            }
            this.klantId = klantId;
            this.email = email;
        }
        public int KlantId => klantId;
        public string Email => email;
    }
}
