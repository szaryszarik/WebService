namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApp.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApp.Models.WebAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApp.Models.WebAppContext context)
        {
            //  This method will be called after migrating to the latest version.

            context.Employees.AddOrUpdate(p => p.EmployeeId,
                new Employee { Name = "Name1", LastName = "LName1" },
                new Employee { Name = "Name2", LastName = "LName2" },
                new Employee { Name = "Name3", LastName = "LName3" }
                );

            context.WorkNotes.AddOrUpdate(r => r.WorkNoteId,
                new WorkNote { Note = "Note1", EmployeeId = 1 },
                new WorkNote { Note = "Note2", EmployeeId = 2 }
                );
        }
    }
}
