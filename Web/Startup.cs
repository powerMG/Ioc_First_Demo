using Core;
using Core.Contract;
using Core.Contract.Environment;
using Core.InputModel.Channel;
using Core.Service;
using Core.ViewModel;
using Core.ViewModel.Channel;
using EntityFramework;
using Hesint.AutoMapper;
using Hesint.Cache;
using Hesint.Core.Mapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Models;
using Web.Helper;

namespace Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ResultFilters));
                options.RespectBrowserAcceptHeader = true;
            }).AddJsonOptions(options =>
            {
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            });
            var connection = Configuration.GetConnectionString("MysqlConnection");
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddAutoMapperServices();
            services.AddCache();
            services.AddScoped<IAreaContract, AreaService>();
            services.AddServices();
            services.AddScoped<ICurrentRequest, Environment>();
            services.AddDbContext<TreeDbContext>(a => a.UseMySql(connection));
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            using(var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var mapper= serviceScope.ServiceProvider.GetService<IMapperConfig>();
                mapper.CreateMapper<AdminLoginViewModel, Administrator>();
                mapper.CreateMapper<Channel, ChannelViewModel>();
                mapper.CreateMapper<ChannelDto, Channel>();
                mapper.InitMapper();
            }
        }

    }
}
