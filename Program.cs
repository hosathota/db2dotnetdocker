using System;
using IBM.Data.DB2.Core;
using System.IO;

namespace DockerTester
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting db2 app 18th Nov");
            string path = Directory.GetCurrentDirectory();
            Console.WriteLine("The current directory is {0}", path);
            
            string[] directories = Directory.GetDirectories(path);

                foreach(string dir in directories)
                {
                    Console.WriteLine("The sub directory is {0}", dir);
                }
            
            Console.WriteLine("The LD_LIBRARY_PATH is {0}", Environment.GetEnvironmentVariable("LD_LIBRARY_PATH"));
            
            try
            {
                DB2Connection connection = new DB2Connection("server=dddd:454545;uid=def;pwd=fdfd;database=defg;SECURITY=SSL;");

                connection.Open();
                Console.WriteLine("Connection opened with server " + connection.ServerVersion);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in opening connection " + ex.Message);
            }

            Console.WriteLine("completed without error");
        }
    }
}
