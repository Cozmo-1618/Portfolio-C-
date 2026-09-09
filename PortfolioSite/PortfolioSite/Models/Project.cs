namespace PortfolioSite.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty; 
        public string Description { get; set; } = string.Empty;
        public string TechStack { get; set; } = string.Empty; // e.g. "C#, ASP.NET MVC, SQL"
        public string? RepoUrl { get; set; }   // link to the GitHub repo for that project
        public string? LiveUrl { get; set; }   // link to the live/deployed version, if any

        /*the ? on some properties (like RepoUrl and EndDate): that's C#'s nullable syntax — it says "this field is genuinely allowed to have no value."*/
        /*A project might not have a live URL yet; 
         * a job/course you're currently doing has no end date. 
         * Compare that to Title, which should never be blank — every project needs one. 
         * This is the same discipline as designing a SQL table: deciding which columns are NOT NULL versus which can be NULL*/
    }
}
