    class Program
    {
        class Customer
        {
            public string? Name { get; set; }
            public string? Phone { get; set; }
        }
        class Order
        {
            public string? Name { get; set; }
            public string? Phone { get; set; }
            public int OrderSize { get; set; }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("=== LINQ Feature Examples ===\n");

            // Query Expressions - Grouping and Ordering
            string[] stringArray = { "apple", "banana", "apricot", "blueberry", "mango", "melon", "mint" };
            var groupedQuery = from str in stringArray group str by str[0] into stringGroup orderby stringGroup.Key select stringGroup;
            Console.WriteLine("Grouped and Ordered Strings:");
            foreach (var group in groupedQuery)
            {
                Console.WriteLine($"Group {group.Key}: {string.Join(", ", group)}");
            }
            // Implicitly Typed Variables
            var number = 5;
            var name = "Virginia";
            var mStrings = from str in stringArray where str[0] == 'm' select str;
            Console.WriteLine("\nStrings starting with 'm':");
            foreach (var s in mStrings)
                Console.WriteLine(s);
            // Object Initializer
            var cust = new Customer { Name = "Mike", Phone = "555-1212" };
            Console.WriteLine($"\nCustomer: {cust.Name}, {cust.Phone}");
            // Sample IncomingOrders data
            var IncomingOrders = new List<Order>
            {
                new Order { Name = "Alice", Phone = "123-4567", OrderSize = 3 },
                new Order { Name = "Bob", Phone = "234-5678", OrderSize = 7 },
                new Order { Name = "Charlie", Phone = "345-6789", OrderSize = 10 }
            };
            // LINQ Query with Object Initialization
            var newLargeOrderCustomersQuery = from o in IncomingOrders where o.OrderSize > 5 select new Customer { Name = o.Name, Phone = o.Phone };
            Console.WriteLine("\nLarge Order Customers (Query Syntax):");
            foreach (var c in newLargeOrderCustomersQuery)
                Console.WriteLine($"{c.Name}, {c.Phone}");
            // Method Syntax Equivalent
            var newLargeOrderCustomersMethod = IncomingOrders
                .Where(x => x.OrderSize > 5)
                .Select(y => new Customer { Name = y.Name, Phone = y.Phone });
            Console.WriteLine("\nLarge Order Customers (Method Syntax):");
            foreach (var c in newLargeOrderCustomersMethod)
                Console.WriteLine($"{c.Name}, {c.Phone}");
            // Anonymous Types
            var anonymousQuery = from c in newLargeOrderCustomersQuery select new { name = c.Name, phone = c.Phone };
            Console.WriteLine("\nAnonymous Type Projection:");
            foreach (var a in anonymousQuery)
                Console.WriteLine($"{a.name}, {a.phone}");
            // Query as Return Value
            int[] nums = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var myQuery1 = QueryMethod1(nums);
            Console.WriteLine("\nQueryMethod1 (i > 4):");
            foreach (var s in myQuery1)
                Console.WriteLine(s);
            // Query as Out Parameter
            QueryMethod2(nums, out IEnumerable<string> myQuery2);
            Console.WriteLine("\nQueryMethod2 (i < 4):");
            foreach (var s in myQuery2)
                Console.WriteLine(s);
            // Composing a new query from an existing one
            myQuery1 = from item in myQuery1 orderby item descending select item;

            Console.WriteLine("\nModified myQuery1 (descending):");
            foreach (var s in myQuery1)
                Console.WriteLine(s);
        }
        static IEnumerable<string> QueryMethod1(int[] ints) =>
            from i in ints where i > 4 select i.ToString();
        static void QueryMethod2(int[] ints, out IEnumerable<string> returnQ) =>
            returnQ = from i in ints where i < 4 select i.ToString();
    }