namespace PortfolioSite.Models
{
    public class Experience
    {
        public int Id { get; set; }
        public string Institution { get; set; } = string.Empty; // e.g. "Rosebank College"
        public string Title { get; set; } = string.Empty;       // e.g. "IT in Software Development"
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; } // nullable: null means "current"
    }
}
