using System.Data.Linq;

namespace LinqConsoleApp
{
    public class Northwind : DataContext
    {
        // Table<T> abstracts database details per table/data type.
        public Table<Customer> Customers;
        public Table<Order> Orders;

        public Northwind(string connection) : base(connection) { }
    }
}
