using Hesint.Lib.Security;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFramework
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider app)
        {
            var _dbContext = app.GetRequiredService<TreeDbContext>();
            if (_dbContext.Administrators.Any())
            {
                return;
            }
            _dbContext.Administrators.AddAsync(new Models.Administrator()
            {
                LoginName = "administrator",
                Password = SHA.SHA512("Password9527@").ToLower()
            });
            _dbContext.SaveChangesAsync();
        }
    }
}
