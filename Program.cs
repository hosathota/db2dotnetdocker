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
                //DB2Connection connection = new DB2Connection("Server = waldevdbcwtst06.dev.rocketsoftware.com:50000; uid = newton; pwd = A2m8test; database = test200");

                //Dash Db
                //DB2Connection connection = new DB2Connection("DATABASE=BLUDB;server=dashdb-txn-sbox-yp-lon02-01.services.eu-gb.bluemix.net:50000;UID=tkr66797;PWD=7j0cn-530x5242gn;");
                //SSL 
                DB2Connection connection = new DB2Connection("server=dddd:454545;uid=def;pwd=fdfd;database=defg;SECURITY=SSL;");

                //zOS
                //
                //DB2Connection connection = new DB2Connection("server=rs23.rocketsoftware.com:3780;uid=newton;pwd=A2m8test;database=RS23LA1A");

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
