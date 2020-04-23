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
            ////Ӧ�ü��м�� ����ʲôurl������ִ�е��⣬�ͻ��·
            // 
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Hello, World!");
            //});

            ////Ӧ�ü��м�� ����ִ���꣬�����������ƥ��·��
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Hello, World!");
            //    await next();
            //});

            ////app.Run()
            ////RequestDelegate û��next��������û������ƥ��
            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("run Hello, World!");
            //});

            ///�Զ����м��
            ///1.xxMiddleware
            ///2.xxMiddlewareExtensions   UseMiddlewareName
            ///3.app.UseMiddlewareName()


            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //�����м���ܵ���֧
            app.Map("/map", app =>
            {
                app.Run(async context =>
                {
                    var endpoint = context.GetEndpoint();  // ʼ�ջ�ȡ����null
                    await context.Response.WriteAsync("����map");
                });
            });

            app.UseRouting();

            //�����м���ܵ���֧
            app.Map("/test", app =>
            {
                app.Run(async context =>
                {
                    var endpoint = context.GetEndpoint();  // ʼ�ջ�ȡ����null
                    await context.Response.WriteAsync("����test");
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
                    await context.Response.WriteAsync("����test1");
                });
            });
        }
    }
}
