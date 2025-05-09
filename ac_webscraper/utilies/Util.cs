using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ac_webscraper.utilies {
    public static class Util {

        private static readonly HashSet<string> TrueValues = new(StringComparer.OrdinalIgnoreCase)
        {
            "provided",
            "yes",
            "true",
            "1",
            "enabled",
            "on"
        };

        public static bool ConvertStringToBool(string input) {
            return input != null && TrueValues.Contains(input.Trim());
        }

        public static int ParseInt(string input) {
            // Remove all non-numeric characters
            string numericPart = new string(input.Where(char.IsDigit).ToArray());

            // Try parsing the numeric part
            return int.TryParse(numericPart, out int result) ? result : 0;
        }

        public static class ImageDownloader {
            public static async Task DownloadImageFromPartPageAsync(string baseUrl, string partId) {
                var url = $"{baseUrl}/wiki/{partId}";
                using var httpClient = new HttpClient();

                try {
                    var html = await httpClient.GetStringAsync(url);
                    var doc = new HtmlDocument();
                    doc.LoadHtml(html);

                    // Find image tag inside <figure>
                    var imgNode = doc.DocumentNode.SelectSingleNode("//figure[contains(@class, 'mw-halign-center')]//img");
                    if (imgNode != null) {
                        var imgUrl = imgNode.GetAttributeValue("src", "");
                        if (!string.IsNullOrWhiteSpace(imgUrl)) {
                            var imageBytes = await httpClient.GetByteArrayAsync(imgUrl);

                            Directory.CreateDirectory("resources"); // Make sure directory exists
                            var fileName = Path.Combine("resources", Path.GetFileName(new Uri(imgUrl).LocalPath));
                            await File.WriteAllBytesAsync(fileName, imageBytes);
                            Console.WriteLine($"[✓] Downloaded image: {fileName}");
                        }
                    }
                }
                catch (Exception ex) {
                    Console.WriteLine($"[✗] Failed to download image for {partId}: {ex.Message}");
                }
            }
        }
    }
}
