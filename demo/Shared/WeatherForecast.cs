using System.ComponentModel.DataAnnotations;

namespace TDesign.Admin.Demo.Shared;
public class WeatherForecast
{
    public int Id { get; set; }
    public DateOnly Date { get; set; }

    public int TemperatureC { get; set; }

    [Required]
    public string? Summary { get; set; } = string.Empty;

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public static IList<WeatherForecast> Data = new List<WeatherForecast>
    {
        new(){Id=1,Date=new DateOnly(2019,7,3), TemperatureC=37, Summary="����"},
        new(){Id=2,Date=new DateOnly(2019,7,4), TemperatureC=36, Summary="�Ϻ�"},
        new(){Id=3,Date=new DateOnly(2019,7,5), TemperatureC=35, Summary="����"},
        new(){Id=4,Date=new DateOnly(2019,7,6), TemperatureC=35, Summary="����"},
        new(){Id=5,Date=new DateOnly(2019,7,7), TemperatureC=37, Summary="����"},
        new(){Id=6,Date=new DateOnly(2019,7,8), TemperatureC=37, Summary="�人"},
        new(){Id=7,Date=new DateOnly(2019,7,9), TemperatureC=33, Summary="����"},
        new(){Id=8,Date=new DateOnly(2019,7,10), TemperatureC=32, Summary="�ɶ�"},
        new(){Id=9,Date=new DateOnly(2019,7,11), TemperatureC=31, Summary="����"},
        new(){Id=10,Date=new DateOnly(2019,7,12), TemperatureC=30, Summary="����"},
        new(){Id=11,Date=new DateOnly(2019,7,13), TemperatureC=36, Summary="֣��"},
        new(){Id=12,Date=new DateOnly(2019,7,14), TemperatureC=35, Summary="̫ԭ"},
        new(){Id=13,Date=new DateOnly(2019,7,15), TemperatureC=33, Summary="���"},
    };



    public static IEnumerable<WeatherForecast> Gets()
    {
        return Data;
    }

    public static void Insert()
    {
        Data.Add(new()
        {
            Id = Data.Count + 1,
            Summary = new Random().NextDouble().ToString(),
            Date = Data[^1].Date.AddDays(1),
            TemperatureC = new Random().Next(25, 40)
        });
    }
}