using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Router
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            ////app.Use()
            ////应用级中间件 无论什么url，都会执行到这，就会短路
            // 
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Hello, World!");
            //});

            ////应用级中间件 这里执行完，还会继续往下匹配路由
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Hello, World!");
            //    await next();
            //});

            ////app.Run()
            ////RequestDelegate 没有next，所以他没有向下匹配
            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("run Hello, World!");
            //});

            ///自定义中间件
            ///1.xxMiddleware
            ///2.xxMiddlewareExtensions   UseMiddlewareName
            ///3.app.UseMiddlewareName()


            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //创建中间件管道分支
            app.Map("/map", app =>
            {
                app.Run(async context =>
                {
                    var endpoint = context.GetEndpoint();  // 始终获取的是null
                    await context.Response.WriteAsync("我是map");
                });
            });

            app.UseRouting();

            //创建中间件管道分支
            app.Map("/test", app =>
            {
                app.Run(async context =>
                {
                    var endpoint = context.GetEndpoint();  // 始终获取的是null
                    await context.Response.WriteAsync("我是test");
                });
            });

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapGet("/", async context =>
                {
                    var endpoint = context.GetEndpoint();
                    await context.Response.WriteAsync("Hello World!");
                });
                
                endpoints.MapGet("/test1", async context =>
                {
                    var endpoint = context.GetEndpoint();
                    await context.Response.WriteAsync("我是test1");
                });
            });
        }
    }
}
