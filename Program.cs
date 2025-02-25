using DrugsService.Serviices;
using System.Dynamic;
namespace DrugsService
{

    internal class Program
    {
        static void Main(string[] args)
        {
            DrugWebAPI api = new DrugWebAPI();
            ExpandoObject input = new ExpandoObject();
            input.TryAdd("val", "אקמול");
            input.TryAdd("prescription", false);
            input.TryAdd("healthServices", false);
            input.TryAdd("pageIndex", 1);
            input.TryAdd("orderBy", 0);

            ExpandoObject result = api.SearchByName(input).Result;
            if (result != null)
            {
                foreach (var item in result)
                {
                    System.Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }
            else
            {
                System.Console.WriteLine("No result");
            }
            Console.WriteLine("Hello, World!");
        }
    }
}
