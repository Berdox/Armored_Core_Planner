

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using ac_webscraper.parsers.ac1;
using static ac_webscraper.models.Mech_Collection;

namespace ac_webscraper {
    class Program {
        private static readonly HttpClient httpClient = new HttpClient();

        static async Task Main(string[] args) {
            var scrapeJobs = new Dictionary<string, Action<HtmlNodeCollection>> {
            { "https://armoredcore.fandom.com/wiki/List_of_First_Generation_Parts", AC1_Parser.parser_ac1 }
            // Add more URL → parser pairs here as needed
        };

            var tasks = scrapeJobs.Select(job => ScrapeAndParse(job.Key, job.Value)).ToList();
            await Task.WhenAll(tasks);

            foreach (var headSet in ac1_mech.head) {
                Console.WriteLine("New Head Set:");
                foreach (var part in headSet) {
                    Console.WriteLine($" - {part}");
                }
            }

            Console.WriteLine("Done scraping");
        }

        static async Task ScrapeAndParse(string url, Action<HtmlNodeCollection> parser) {
            try {
                Console.WriteLine($"\n[Fetching] {url}");
                var html = await httpClient.GetStringAsync(url);

                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);

                var tbodyNodes = htmlDoc.DocumentNode.SelectNodes("//tbody");

                if (tbodyNodes != null) {
                    Console.WriteLine($"[Parsed] {url} - Found {tbodyNodes.Count} <tbody> tag(s)");
                    parser(tbodyNodes);
                }
                else {
                    Console.WriteLine($"[Info] {url} - No <tbody> tags found.");
                }
            }
            catch (Exception ex) {
                Console.WriteLine($"[Error] Scraping {url}: {ex.Message}");
            }
        }
    }

}
