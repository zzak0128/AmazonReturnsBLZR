﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazonReturnsInventoryUI.Model;
using AmazonReturnsInventoryLibrary.Transactions;
using AmazonReturnsInventoryUI.Model.Items;
using AmazonReturnsInventoryUI.Model.Orders;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AmazonReturnsInventoryUI.Model.SupplyItems;

namespace AmazonReturnsInventoryUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("ZakOps"));
            });

            //services.AddDbContext<ApplicationDbContext>(options =>
            //{
            //    options.UseSqlite("Data Source=AmazonReturns.db");
            //});
            services.AddScoped<TransactionService>();
            services.AddScoped<OrderService>();
            services.AddScoped<ItemService>();
            services.AddScoped<SupplyItemService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
