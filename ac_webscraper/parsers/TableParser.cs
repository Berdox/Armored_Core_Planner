using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SixLabors.ImageSharp;

using ac_webscraper.models;

namespace ac_webscraper.parsers {

    public static class TableParser {
        public static void ParseTable(List<(Image image, List<string>)> model, HtmlNode tbody, AC_Games game) {

            var rows = tbody.SelectNodes(".//tr");
            if (rows == null) return;

            foreach (var row in rows) {
                // Extract the PartId from the <th> (the first column)
                List<string> part = new List<string>();
                Image partImage = new();
                part.Add(WhichGame(game));
                var partIdNode = row.SelectSingleNode(".//th/a");
                part.Add(partIdNode?.InnerText.Trim() ?? "Unknown"); // Default to "Unknown" if no <a> tag is found

                // Now process the <td> elements
                var cells = row.SelectNodes(".//td");
                if (cells == null) continue;

                // Iterate through each <td> cell and map the rest of the values
                for (int i = 0; i < cells.Count; i++) {
                    var cellText = cells[i].InnerText.Trim();
                    part.Add(cellText);
                }
                model.Add((partImage, part));
            }
        }

        public static string WhichGame(AC_Games game) {
            switch ((int)game) {
                case 1:
                    return "ac1";
                case 2:
                    return "ac1_PP";
                case 3:
                    return "ac1_MOA";
                case 4:
                    return "ac2";
                case 5:
                    return "ac2_AA";
                case 6:
                    return "ac3";
                case 7:
                    return "ac3_portable";
                case 8:
                    return "ac3_SL";
                case 9:
                    return "ac3_SL_portable";
                case 10:
                    return "ac3_N";
                case 11:
                    return "ac3_NB";
                case 12:
                    return "ac3_LR";
                case 13:
                    return "ac3_LR_portable";
                case 14:
                    return "ac4";
                case 15:
                    return "ac4_FA";
                default:
                    return "unknown";
            }
        }
    }
}
