using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using ToDoList.DataAccess;

namespace ToDoList
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
       
            builder.Services.AddDbContext<TaskListDbContext>(options =>
               options.UseSqlServer("Server=localhost;Database=ToDoAappDB;Trusted_Connection=True;TrustServerCertificate=true"));
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
