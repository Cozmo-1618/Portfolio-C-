using PortfolioSite.Models;

namespace PortfolioSite.Data
{
    /*
     Rather than typing data into a database manually, EF lets you seed initial rows in code — 
     so your bio/skills/experience live in your project (and Git history) as data, 
     not something you'd have to re-enter if the database ever got rebuilt.
     */
    public class SeedData
    {
        public static void Initialize(PortfolioDbContext context)
        {
            if (context.Bios.Any()) return; // DB already seeded, don't duplicate
            /*
             Why the if (context.Bios.Any()) return; guard exists: without it, every time your app restarts, 
             it would try to re-insert the same rows, duplicating your data endlessly. 
             It's a simple "have I already done this?" check — the same instinct as checking a save file exists before overwriting it with a fresh "New Game."
             */

            context.Bios.Add(new Bio
            {
                FullName = "Koketso Leopeng",
                Tagline = "Game fanatic turned software developer",
                AboutText = "My love for tech started through gaming — wondering how a button press " +
                             "moved my character, or how a game knew to save my progress. That curiosity " +
                             "led me to coding with Delphi at Hoerskool Birchleigh, then Information " +
                             "Technology in Software Development at Rosebank College."
            });

            context.Experiences.AddRange(
                new Experience
                {
                    Institution = "Hoerskool Birchleigh",
                    Title = "High School - IT & Delphi",
                    Description = "First introduction to coding, using Delphi.",
                    StartDate = new DateTime(2017, 1, 1),
                    EndDate = new DateTime(2021, 12, 1)
                },
                new Experience
                {
                    Institution = "Rosebank College",
                    Title = "IT in Software Development",
                    Description = "Studied Business Information Systems, Java, C#, PHP, and System Analysis and Design.",
                    StartDate = new DateTime(2023, 2, 7),
                    EndDate = new DateTime(2025, 12, 31)
                }
            );

            context.Skills.AddRange(
                new Skill { Name = "C#", Category = "Language", ProficiencyLevel = 4 },
                new Skill { Name = "Java", Category = "Language", ProficiencyLevel = 3 },
                new Skill { Name = "PHP", Category = "Language", ProficiencyLevel = 4 },
                new Skill { Name = "SQL / MySQL", Category = "Database", ProficiencyLevel = 4 },
                new Skill { Name = "HTML/CSS/JavaScript", Category = "Web", ProficiencyLevel = 4 },
                new Skill { Name = "Git & GitHub", Category = "Tool", ProficiencyLevel = 4 }
            );

            context.Projects.AddRange(
                new Project
                {
                    Title = "Portfolio Site",
                    Description = "A personal portfolio website built with ASP.NET Core MVC.",
                    RepoUrl = "https://github.com/yourusername/PortfolioSite",
                    LiveUrl = "https://yourusername.github.io/PortfolioSite",
                    TechStack = "ASP.NET Core MVC, C#, HTML, CSS, JavaScript"
                },
                new Project
                {
                    Title = "Todo List",
                    Description = "A simple To-do list management application.",
                    RepoUrl = "https://github.com/yourusername/TodoList",
                    LiveUrl = "https://yourusername.github.io/TodoList",
                    TechStack = "ASP.NET Core MVC, C#, HTML, CSS, JavaScript"
                }
            );

            context.SaveChanges();
        }
    }
}
