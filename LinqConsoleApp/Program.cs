using System;
using System.Data.Linq;
using System.Linq;

namespace LinqConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Use a connection string.
            Northwind db = new Northwind
                (@"D:\School Work\ITC 466\Melton_Homework6\ITC_466_Melton_Homework6\linqtest5\northwnd.mdf");
            // Get a typed table to run queries.
            Table<Customer> Customers = db.GetTable<Customer>();

            // Attach the log to show generated SQL.
            //db.Log = Console.Out;

            // Query for customers in London.
            IQueryable<Customer> custQuery =
                from cust in db.Customers
                where cust.City == "London"
                select cust;

            foreach(Customer cust in custQuery)
            {
                Console.WriteLine("ID={0}, City={1}", cust.CustomerID, cust.City);
            }

            Console.WriteLine("**********************************");

            custQuery =
                from cust in Customers
                where cust.Orders.Any()
                select cust;

            foreach(var custObj in custQuery)
            {
                Console.WriteLine("ID={0}, Qty={1}", custObj.CustomerID, custObj.Orders.Count);
            }

        }
    }
}
