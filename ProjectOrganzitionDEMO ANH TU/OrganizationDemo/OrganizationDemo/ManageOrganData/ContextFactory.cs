using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationDemo.ManageOrganData
{
    public static class FContextFactory
    {
        public static ApplicationContext Create(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer(connectionString);
            // Ensure that the SQLServer database and sechema is created!
            var context = new ApplicationContext(optionsBuilder.Options);
            context.Database.EnsureCreated();

            return context;
        }
    }

}
