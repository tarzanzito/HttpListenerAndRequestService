using System;
using System.Reflection;

namespace HttpListenerConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int port = 8888;
            if (args.Length == 1)
                port = Int32.Parse(args[0]);

            Console.WriteLine(TitleInfo());
            Console.WriteLine("Start Server...");

            HttpListenerConsole.MyWebService webService = new HttpListenerConsole.MyWebService();
            webService.StartWebServer(port);
        }

        private static string TitleInfo()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            AssemblyTitleAttribute attr1 = (AssemblyTitleAttribute)Attribute.GetCustomAttribute(assembly, typeof(AssemblyTitleAttribute), false);
            string title = attr1.Title;

            AssemblyCompanyAttribute attr2 = (AssemblyCompanyAttribute)Attribute.GetCustomAttribute(assembly, typeof(AssemblyCompanyAttribute), false);
            string company = attr2.Company;

            string version = assembly.GetName().Version.ToString();

            return title + " - Version: " + version + " (By '" + company + "')";
        }
    }
}
