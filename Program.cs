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
            
            Console.WriteLine("The connection details are server, port, uid, pwd : {0} , {1}, {2}, {3}", server, port, uid,pwd );    
            
            try
            {
                DB2Connection connection = new DB2Connection("server=myserver:50000;uid=myuid;pwd=mypwd;database=mydb;SECURITY=SSL;");
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
