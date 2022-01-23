using System;

namespace Module4HW3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var cf = new ContextFactory();
            using (var context = cf.CreateDbContext(null))
            {
            }

            Console.ReadLine();
        }
    }
}