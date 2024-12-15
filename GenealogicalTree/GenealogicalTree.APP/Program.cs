using GenealogicalTree.APP.UI;
using GenealogicalTree.BLL.Contract;
using GenealogicalTree.BLL.Service;
using GenealogicalTree.DAL.Infrastructure;
using GenealogicalTree.DAL.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GenealogicalTree.APP;

class Program
{
    static void Main(string[] args)
    {
        var container = new ServiceCollection()
                .AddDbContext<TreeDbContext>(
                    options =>
                        options.UseSqlite("data/database.db")
                )
                .AddScoped<IPersonRepository, DbPersonRepository>()
                .AddScoped<IPersonService, PersonService>()
                .AddScoped<ITreeService, TreeService>()
                .AddScoped<ITreePrinter, ConsoleTreePrinter>()
                .AddSingleton<TreeApp>()
            ;

        var serviceProvider = container.BuildServiceProvider();
        var app = serviceProvider.GetRequiredService<TreeApp>();
        app.Run();
    }
}