using HtmlAgilityPack;
using System;
using System.Net.Http;

namespace WebScraper
{
    class Program
    {
        static void Main(String[] args)
        {
            // Send get request weather.com
            String url = "https://weather.com/weather/today/l/e09a0f01a971957f8a9f31ee691c35b56ba92ef416acfa76e16f33578f291c0b?unit=m";
            var httpClient = new HttpClient();
            var html = httpClient.GetStringAsync(url).Result;
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            // Get location
            var locationElement = htmlDocument.DocumentNode.SelectSingleNode("//h1[@class='CurrentConditions--location--1YWj_']");
            var location = locationElement?.InnerText.Trim();
            Console.WriteLine($"Location: {location}");

            // Get temperature
            var temperatureElement = htmlDocument.DocumentNode.SelectSingleNode("//span[@class='CurrentConditions--tempValue--MHmYY']");
            var temperature = temperatureElement?.InnerText.Trim();
            Console.WriteLine($"Temperature: {temperature}");

            // Get conditions
            var conditionElement = htmlDocument.DocumentNode.SelectSingleNode("//div[@class='CurrentConditions--phraseValue--mZC_p']");
            var condition = conditionElement?.InnerText.Trim();
            Console.WriteLine($"Conditions: {condition}");

            // Get last update
            var updateElement = htmlDocument.DocumentNode.SelectSingleNode("//span[@class='CurrentConditions--timestamp--1ybTk']");
            var update = updateElement?.InnerText.Trim();
            Console.WriteLine(update);

        }
    }
}