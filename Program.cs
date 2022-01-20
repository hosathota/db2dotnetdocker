using System;
using IBM.Data.DB2.Core;
using System.IO;
using System.Diagnostics;

namespace DockerTester
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting db2 app");
            string path = Directory.GetCurrentDirectory();
            Console.WriteLine("The current directory is {0}", path);                  
            string server=Environment.GetEnvironmentVariable("server");
            string port=Environment.GetEnvironmentVariable("port");
            string uid=Environment.GetEnvironmentVariable("uid");
            string pwd=Environment.GetEnvironmentVariable("pwd");
            string database=Environment.GetEnvironmentVariable("database");
            
            Console.WriteLine("The connection details are server, port, uid, pwd, database : {0} , {1}, {2}, {3}, {4}", server, port, uid,pwd, database );    
            
           Console.WriteLine("LD Library path is "+   Environment.GetEnvironmentVariable("LD_LIBRARY_PATH"));
            try
            {
                DB2Connection connection = new DB2Connection("server={0}:{1};uid={2};pwd={3};database={4};SECURITY=SSL;", server, port, uid, pwd, database);
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
