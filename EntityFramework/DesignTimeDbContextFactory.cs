using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TreeDbContext>

    {

        public TreeDbContext CreateDbContext(string[] args)

        {

            var builder = new DbContextOptionsBuilder<TreeDbContext>();

            
            builder.UseMySql("UserID = root; Password = xmwang1.q; Host = 47.104.139.46; Port=3306; Database = cms");

            return new TreeDbContext(builder.Options);

        }

    }
}
