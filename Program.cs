using System;
using IBM.Data.Db2;

namespace DockerTest6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            try
            {
                DB2Connection connection = new DB2Connection("server=test;");

                connection.Open();
                Console.WriteLine("zOS Connection opened with server " + connection.ServerVersion);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error in opening connection "+ex.Message);
            }

            Console.WriteLine("completed without error");
        }
    }
}
