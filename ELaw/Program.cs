using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ELaw.Models;
using System.IO;

namespace ELaw
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //String filePath = "text.txt";
            //WriteToFile(filePath);
            CreateHostBuilder(args).Build().Run();
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(LawReview));
        }
        //public static void WriteToFile(string filePath)
        //{
        //    StreamWriter writer = new StreamWriter(filePath, true);
        //    String temp = String.Empty;

        //    do
        //    {
        //        Console.Write("Enter a name[-1 to exit]: ");
        //        temp = Console.ReadLine();
        //        if (temp != "-1")
        //        {
        //            writer.WriteLine(temp);
        //        }
        //    } while (temp != "-1");
        //    writer.Close();
        //}

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
