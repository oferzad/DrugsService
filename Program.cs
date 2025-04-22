using DrugsService.Serviices;
using System.Dynamic;
using System.Text.Json;
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
            dynamic test = result;
            JsonElement test1 = test.results[0];
            dynamic json = JsonSerializer.Deserialize<ExpandoObject>(test1);
            string dragEnName = JsonSerializer.Deserialize<string>(json.dragEnName);

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
