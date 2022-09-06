using System.Net.Http.Headers;
using System.Net.Http.Json;
using TestCRUDApi;

HttpClient client = new HttpClient();
client.BaseAddress = new Uri("https://localhost:7172");
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applicatin/json"));

HttpResponseMessage response = await client.GetAsync("api/products");
if (response.IsSuccessStatusCode)
{
    var products = await response.Content.ReadFromJsonAsync<IEnumerable<IssueData>>();
    foreach (var product in products)
    {
        Console.WriteLine("Id: {0}", product.Id);
        Console.WriteLine("Name: {0}", product.Name);
        Console.WriteLine("Price: {0}", product.Price);
        
    }
}
else
{
    Console.WriteLine("No Results");
}