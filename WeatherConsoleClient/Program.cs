using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherConsoleClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // Создание HttpClient
            using (var client = new HttpClient())
            {
                // Установка базового адреса
                client.BaseAddress = new Uri("https://localhost:7233/WeatherForecast");

                // Отправка GET запроса для получения данных о погоде
                try
                {
                    var response = await client.GetAsync(""); // Пустой путь, так как контроллер настроен на /weatherforecast

                    if (response.IsSuccessStatusCode)
                    {
                        var weatherData = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Weather data: ");
                        Console.WriteLine(weatherData);
                    }
                    else
                    {
                        Console.WriteLine("Ошибка при получении данных о погоде.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла ошибка: {ex.Message}");
                }
                Console.ReadKey();
            }
        }
    }
}
