

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using ac_webscraper.parsers.ac1;
using armored_core_planner.Models.ac1;

namespace ac_webscraper {
    class Program {
        static async Task Main(string[] args) {
            List<string> urls = new List<string> {
            "https://armoredcore.fandom.com/wiki/List_of_First_Generation_Parts"
        };

            var parsers = new Dictionary<string, Action<HtmlNodeCollection>> {
            { "https://armoredcore.fandom.com/wiki/List_of_First_Generation_Parts", AC1_Parser.parser_ac1 }
        };

            var tasks = urls.Select(url => ScrapeAndParse(url, parsers)).ToList();
            await Task.WhenAll(tasks);
        }

        static async Task ScrapeAndParse(string url, Dictionary<string, Action<HtmlNodeCollection>> parsers) {
            try {
                using var httpClient = new HttpClient();
                var html = await httpClient.GetStringAsync(url);

                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);

                var tbodyNodes = htmlDoc.DocumentNode.SelectNodes("//tbody");

                if (tbodyNodes != null) {
                    Console.WriteLine($"\n[{url}] Found {tbodyNodes.Count} <tbody> tag(s)");
                    if (parsers.TryGetValue(url, out var parser)) {
                        parser(tbodyNodes);
                    }
                    else {
                        Console.WriteLine($"No parser registered for URL: {url}");
                    }
                }
                else {
                    Console.WriteLine($"\n[{url}] No <tbody> tags found.");
                }
            }
            catch (Exception ex) {
                Console.WriteLine($"Error scraping {url}: {ex.Message}");
            }

            Console.WriteLine(AC1_Mech.ac1_heads[0].PartId);
            Console.WriteLine(AC1_Mech.ac1_heads[0].Price);
            Console.WriteLine(AC1_Mech.ac1_heads[0].Weight);
        }
    }


    /*class Program {
        static async Task Main(string[] args) {
            List<string> urls = new List<string>
            {
                "https://armoredcore.fandom.com/wiki/List_of_First_Generation_Parts"
                };

            // Modular parser dictionary
            var parsers = new Dictionary<string, Action<HtmlNodeCollection>>
            {
                { "https://armoredcore.fandom.com/wiki/List_of_First_Generation_Parts", AC1_Parser.parser_ac1 },
            };

            var tasks = new List<Task>();
            foreach (var url in urls) {
                tasks.Add(ScrapeAndParse(url, parsers));
            }

            await Task.WhenAll(tasks);
        }

        static async Task ScrapeAndParse(string url, Dictionary<string, Action<HtmlNodeCollection>> parsers) {
            try {
                using var httpClient = new HttpClient();
                var html = await httpClient.GetStringAsync(url);

                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);

                var tbodyNodes = htmlDoc.DocumentNode.SelectNodes("//tbody");

                if (tbodyNodes != null) {
                    Console.WriteLine($"\n[{url}] Found {tbodyNodes.Count} <tbody> tag(s)");

                    string host = new Uri(url).Host;
                    if (parsers.TryGetValue(host, out var parser)) {
                        parser(tbodyNodes); // Call the matching parser
                    }
                    else {
                        Console.WriteLine($"No parser registered for host: {host}");
                    }
                }
                else {
                    Console.WriteLine($"\n[{url}] No <tbody> tags found.");
                }
            }
            catch (Exception ex) {
                Console.WriteLine($"Error scraping {url}: {ex.Message}");
            }
        }
    }*/
}
