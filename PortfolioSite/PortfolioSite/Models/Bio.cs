namespace PortfolioSite.Models
{
    public class Bio
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Tagline { get; set; } = string.Empty;   // short one-liner, e.g. "Tech fanatic turned developer"
        public string AboutText { get; set; } = string.Empty; // the longer story
        public string? ProfileImageUrl { get; set; }
    }
}
