namespace PortfolioSite.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; /*string.Empty defaults instead of leaving them null —
                                                          * this avoids NullReferenceException crashes later 
                                                          * when a View tries to display Name and it was never set.*/
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty; // e.g. "Language", "Framework", "Database"
        public int ProficiencyLevel { get; set; } // 1-5, or whatever scale you like
    }
}
