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
            Console.WriteLine("Starting db2 app 1st December");
            //string path = Directory.GetCurrentDirectory();
            //Console.WriteLine("The current directory is {0}", path);
            
            //string[] directories = Directory.GetDirectories(path);

                //foreach(string dir in directories)
                //{
                    //Console.WriteLine("The sub directory is {0}", dir);
                //}
            
            //Console.WriteLine("Before setting : LD_LIBRARY_PATH is {0}", Environment.GetEnvironmentVariable("LD_LIBRARY_PATH"));
            
            //Environment.SetEnvironmentVariable("LD_LIBRARY_PATH", path+@"/clidriver/lib");
            
            //Console.WriteLine("The LD_LIBRARY_PATH is {0}", Environment.GetEnvironmentVariable("LD_LIBRARY_PATH"));
            
            //ProcessStartInfo startInfo = new ProcessStartInfo() { FileName = "/bin/bash", Arguments = "ls", };
                //Process proc = new Process() { StartInfo = startInfo, };
                //proc.Start();
            
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
