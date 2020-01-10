using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RoutineApi.DbContexts;

namespace RoutineApi
{
    public class Program
    {

        //����Ŀ������Microsoft mvp ���� https://www.cnblogs.com/cgzl/p/11814971.html
        public static void Main(string[] args)
        {
            //ÿ����������ɾ����Ǩ��
            var host = CreateHostBuilder(args).Build();
            using (var scope=host.Services.CreateScope())
            {
                try
                {
                    var dbContext = scope.ServiceProvider.GetService<RoutineDbContext>();
                    dbContext.Database.EnsureCreated();//EnsureDeleted ������ɾ�����ݿ⣨������ڣ��� �����û����Ӧ��Ȩ�ޣ���������쳣
                    dbContext.Database.Migrate();//Ǩ��
                }
                catch (Exception e)
                {
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(e,"Ǩ��ʱ��������");
                }
                host.Run();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
