using System.Net.Http.Json;
using System.Text.Json;
using Deserializer.Models;

// For Extension method
// var opt = new JsonSerializerOptions
// {
//     PropertyNameCaseInsensitive = true
// };

using HttpClient client = new()
{
    BaseAddress = new Uri("http://localhost:5018")
};

var response = await client.GetAsync("weatherforecast");

if (response.IsSuccessStatusCode)
{
    var jsonString = await response.Content.ReadAsStringAsync();

    using (JsonDocument jsonDocument = JsonDocument.Parse(jsonString))
    {
        JsonElement root = jsonDocument.RootElement;
        Console.WriteLine(root.ValueKind);
        foreach (var temp in root.EnumerateArray())
        {
            Console.WriteLine(temp.GetProperty("summary").ToString());
        }
    }
}
else
{
    Console.WriteLine($"Whoops ! Error: {response.StatusCode}");
}
// Extension method
// var temperatures = await client.GetFromJsonAsync<Temperature[]>("weatherforecast", opt);

// if (temperatures != null)
// {
//     foreach (var temp in temperatures)
//     {
//         Console.WriteLine($"Summary: {temp.Summary}");
//     }
// }

// string fileName = "person.json";
// string jsonString = File.ReadAllText(fileName);
// Person? person = JsonSerializer.Deserialize<Person>(jsonString, opt);
// Console.WriteLine($"The first name is: {person!.LastName}");


// Not recomandble
// using HttpClient client = new()
// {
//     BaseAddress = new Uri("http://localhost:5018")
// };

// var response = await client.GetAsync("weatherforecast");

// if (response.IsSuccessStatusCode)
// {
//     var temperatures = await JsonSerializer.
//                         DeserializeAsync<Temperature[]>
//                         (await response.Content.ReadAsStreamAsync(), opt);
//     if (temperatures != null)
//     {
//         foreach (var temp in temperatures)
//         {
//             Console.WriteLine($"Summary: {temp.Summary}");
//         }
//     }
// }
// else
// {
//     Console.WriteLine($"Whoops! Error: {response.StatusCode}");
// }

