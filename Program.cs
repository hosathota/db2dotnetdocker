using System;
using IBM.Data.DB2.Core;

namespace DockerTester
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
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
