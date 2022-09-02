using System.Text.Json;
using Serializer.Helpers;
using Serializer.Models;

var person = new Person
{
    Id = 1,
    FirstName = "Sean",
    LastName = "Connery",
    Age = 90,
    IsAlive = false,
    Address = new Address
    {
        StreetName = "1 main street",
        City = "New York",
        ZipCode = "12345"
    },
    Phones = new List<Phone>()
    {
        new Phone { PhoneType = "Home", PhoneNumber = "2321413412"},
        new Phone { PhoneType = "Home", PhoneNumber = "2657675676"}
    }
};

var opt = new JsonSerializerOptions
{
    WriteIndented = true,
    // PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    PropertyNamingPolicy = new LowerCaseNamingPolicy(),
    // IncludeFields = true
};

string jsonString = JsonSerializer.Serialize<Person>(person, opt);
string fileName = "person.json";

File.WriteAllText(fileName, jsonString);

Console.WriteLine(File.ReadAllText(fileName));