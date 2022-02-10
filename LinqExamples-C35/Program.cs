using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExamples_C35 {
    class Program {
        static void Main(string[] args) {

            //int[] ints = new int[]
            //          int[] ints = new int[] {
            //  869,    842,    861,    672,    757,    144,    397,    110,    109,    111,
            //  104,    348,    551,    624,    141,    887,    792,    395,    281,    737,
            //  612,    740,    574,    313,    672,    404,    523,    507,    843,    164,
            //  233,    115,    338,    905,    378,    761,    169,    666,    354,    453,
            //  501,    469,    406,    948,    417,    149,    909,    334,    321,    645,
            //  370,    933,    483,    770,    681,    631,    108,    151,    726,    876,
            //  869,    464,    827,    678,    240,    971,    903,    709,    380,    246,
            //  733,    915,    503,    474,    445,    866,    152,    447,    560,    387,
            //  726,    314,    477,    523,    483,    452,    250,    966,    677,    442,
            //  841,    278,    406,    787,    710,    769,    570,    145,    555,    774
            // }

            List<Customer> customers = new List<Customer>() {

                new Customer() { Id = 1, Name = "Max", Sales = 1000 },
                new Customer() { Id = 1, Name = "PG", Sales = 10000 },
                new Customer() { Id = 1, Name = "Micrsoft", Sales = 10000 },
            };
            List<Order> orders = new List<Order>() {
                new Order() { Id = 1, Description = "1st order",
                                Total = 1000, CustomerId = 2 },
                new Order() { Id = 2, Description = "2nd order",
                                Total = 2000, CustomerId = 5 },
                new Order() { Id = 3, Description = "3st order",
                                Total = 3000, CustomerId = 1 }
            };

            var customerOrders = from o in orders
                                 join c in customers
                                 on o.CustomerId equals c.Id
                                 orderby o.Total descending
                                 select new {
                                     o.Id, o.Description,
                                     Amount = o.Total,
                                     Customer = c.Name
                                 };
            foreach (var co in customerOrders) {
                Console.WriteLine($"{co.Id,-5}{co.Description,-30}" +
                    $"{co.Amount,7:c}{co.Customer,25}");
            }

            var orderedCustomers = from c in customers
                                   orderby c.Sales descending
                                   select new {
                                   c.Name, c.Sales
                                  };
            foreach (var c in orderedCustomers) {
                Console.WriteLine($"{c.Name,-15} {c.Sales:15:c}");
            }
            

            int[] numbers = { 23, 28, 225, 35, 500, 22, 15,
                                -63, 7, 88, 53, -1, 12, 17 };

                Console.WriteLine($"Total is {numbers.Sum()}");

            var qnbrs = from n in numbers //assigns numbers to alias n in this query statement
                        where n < 200    // optional
                        orderby n        // optional
                        select n;

            int[] numLT200 = numbers.Where(t => t < 200).ToArray();

            int[] numGTE50LTE100 = numbers.Where(nbr => nbr >= 50 && nbr <= 100).ToArray();

            int[] numbers2 = numbers
                            .Where(n => n % 2 == 1)
                            .OrderByDescending(x => x)
                            .ToArray();
            
            foreach(int lt in numLT200) {
                Console.Write($"{lt} ");
            }
            
            foreach(int n1 in numbers2) {                
                Console.Write($"{n1} ");           
            }

            // The above statement does this

            int total = 0;
            foreach (int n in numbers) {
                if (n % 2 == 1) {
                total += n;
            Console.WriteLine($"{n} ");
                }
            }
            Console.Write(total);
        }
        
        
        
           
    }
}
