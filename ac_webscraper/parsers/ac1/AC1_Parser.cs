using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HtmlAgilityPack;
using armored_core_planner.Models.ac1;
using ac_webscraper.utilies;

namespace ac_webscraper.parsers.ac1 {

    public static class AC1_Parser {
        public static void parser_ac1(HtmlNodeCollection tbodies) {
            Console.WriteLine("Parsing AC1...");

            for (int i = 0; i < tbodies.Count; i++) {
                var tbody = tbodies[i];

                switch (i) {
                    case 0:
                        TableParser.ParseTable(
                            tbody,
                            () => new AC1_Head_Model(),
                            (m, cell, index) => {
                                // Handle PartId (first column)
                                if (index == 0) {
                                    m.PartId = cell; // Map PartId
                                }
                                else {
                                    // Handle the rest of the cells
                                    switch (index) {
                                        case 1: m.Price = Util.ParseInt(cell); break;
                                        case 2: m.Weight = Util.ParseInt(cell); break;
                                        case 3: m.EnDrain = Util.ParseInt(cell); break;
                                        case 4: m.ArmorPoints = Util.ParseInt(cell); break;
                                        case 5: m.DefShell = Util.ParseInt(cell); break;
                                        case 6: m.DefEnergy = Util.ParseInt(cell); break;
                                        case 7: m.ComputerType = cell; break;
                                        case 8: m.MapType = cell; break;
                                        case 10: m.NoiseCanceler = Util.ConvertStringToBool(cell); break;
                                        case 11: m.BioSensor = Util.ConvertStringToBool(cell); break;
                                        case 12: m.RadarFunction = Util.ConvertStringToBool(cell); break;
                                        case 13: m.RadarRange = Util.ParseInt(cell); break;
                                        case 14: m.Unlock = cell; break;
                                        case 15: m.Notes = cell; break;
                                    }
                                }
                            },
                            m => AC1_Mech.ac1_heads.Add(m) // Add model to collection
                        );
                        break;

                        // Add more cases for core, arms, legs etc.
                }
            }
        }
    }
}
