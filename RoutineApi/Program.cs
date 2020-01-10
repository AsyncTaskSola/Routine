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

        //本项目来自于Microsoft mvp 杨旭 https://www.cnblogs.com/cgzl/p/11814971.html
        public static void Main(string[] args)
        {
            //每次启动都会删除再迁移
            var host = CreateHostBuilder(args).Build();
            using (var scope=host.Services.CreateScope())
            {
                try
                {
                    var dbContext = scope.ServiceProvider.GetService<RoutineDbContext>();
                    dbContext.Database.EnsureCreated();//EnsureDeleted 方法会删除数据库（如果存在）。 如果你没有相应的权限，则会引发异常
                    dbContext.Database.Migrate();//迁移
                }
                catch (Exception e)
                {
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(e,"迁移时发生错误");
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
