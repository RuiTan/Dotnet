using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace dotnet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // using (DataContext data = new DataContext()){
            //     User user = new User();
            //     user.Id = 10;
            //     user.Username = "tanrui";
            //     user.Password = "12";
            //     data.Users.Add(user);
            //     Console.WriteLine(user);
            // }
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
