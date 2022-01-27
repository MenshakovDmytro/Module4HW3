using System;
using System.Threading.Tasks;

namespace Module4HW3
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await using (var context = new ContextFactory().CreateDbContext(args))
            {
                await new LazyLoadingWork(context).Run();
            }
        }
    }
}