using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONetDemoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString
                = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Student\\Desktop\\Caines-Michael-w0244079\\ADONetDemoApp\\ADONetDemoApp\\Northwind.mdf;Integrated Security=True;Connect Timeout=30";


            //data read example
            //DataReadExample ex = new DataReadExample(connectionString);
            //ex.RunDemo();

            //data update example
            //DataUpdateExample ex = new DataUpdateExample(connectionString);
            //ex.RunDemo();

            //stored proc example
            //StoredProcExample ex = new StoredProcExample(connectionString);
            //ex.RunDemo();

            //stored proc with params example
            StoredProcExampleWithParams ex = new StoredProcExampleWithParams(connectionString);
            ex.RunDemo();

            Console.Read(); //keep console open

        }
    }
}
