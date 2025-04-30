using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ac_webscraper.parsers {

    public static class TableParser {
        // Updated method to handle PartId in <th> and map the rest of the <td> elements
        public static void ParseTable<T>(HtmlNode tbody, Func<T> modelFactory, Action<T, string, int> mapCell, Action<T> addModel = null) {
            var rows = tbody.SelectNodes(".//tr");
            if (rows == null) return;

            foreach (var row in rows) {
                // Extract the PartId from the <th> (the first column)
                var partIdNode = row.SelectSingleNode(".//th/a");
                string partId = partIdNode?.InnerText.Trim() ?? "Unknown"; // Default to "Unknown" if no <a> tag is found

                // Now process the <td> elements
                var cells = row.SelectNodes(".//td");
                if (cells == null) continue;

                // Create a new model instance
                T model = modelFactory();

                // Special handling for PartId (assuming index 0 is <th> partId)
                mapCell(model, partId, 0); // Map the PartId to the model

                // Iterate through each <td> cell and map the rest of the values
                for (int i = 0; i < cells.Count; i++) {
                    var cellText = cells[i].InnerText.Trim();
                    mapCell(model, cellText, i + 1); // Increment index to map cells starting from index 1
                }

                // Optionally add the model to the collection
                addModel?.Invoke(model);
            }
        }
    }

    /*public static class TableParser {
        public static void ParseTable<T>(HtmlNode tbody, Func<T> modelFactory, Action<T, string, int> mapCell, Action<T> addModel = null) {
            var rows = tbody.SelectNodes(".//tr");
            if (rows == null) return;

            foreach (var row in rows) {
                var cells = row.SelectNodes(".//td");
                if (cells == null) continue;

                T model = modelFactory();
                for (int i = 0; i < cells.Count; i++) {
                    var cellText = cells[i].InnerText.Trim();
                    mapCell(model, cellText, i);
                }

                addModel?.Invoke(model);
            }
        }
    }*/

}
