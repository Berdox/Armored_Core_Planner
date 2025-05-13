using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ac_webscraper.models;
using HtmlAgilityPack;
using SixLabors.ImageSharp;
using static ac_webscraper.parsers.TableParser;
using static ac_webscraper.models.Mech_Collection;

namespace ac_webscraper.parsers.ac2 {
    public static class AC2_Parser {

        private static readonly (List<(Image image, List<string>)> model, AC_Games game)[] ParseMap_AC2 = new[] {
            (ac2_mech.head, AC_Games.ac2),        
            (ac2_mech.head, AC_Games.ac2_AA),     
            (ac2_mech.core, AC_Games.ac2),         
            (ac2_mech.arms, AC_Games.ac2),        
            (ac2_mech.legs, AC_Games.ac2),       
            (ac2_mech.legs, AC_Games.ac2_AA),    
            (ac2_mech.booster, AC_Games.ac2),     
            (ac2_mech.fcs, AC_Games.ac2),          
            (ac2_mech.generator, AC_Games.ac2),   
            (ac2_mech.radiator, AC_Games.ac2),    
            (ac2_mech.inside, AC_Games.ac2),       
            (ac2_mech.inside, AC_Games.ac2_AA),    
            (ac2_mech.extension, AC_Games.ac2),    
            (ac2_mech.extension, AC_Games.ac2_AA), 
            (ac2_mech.backUnit, AC_Games.ac2),     
            (ac2_mech.backUnit, AC_Games.ac2_AA),  
            (ac2_mech.armR, AC_Games.ac2),         
            (ac2_mech.armR, AC_Games.ac2_AA),      
            (ac2_mech.armL, AC_Games.ac2),         
            (ac2_mech.armL, AC_Games.ac2_AA),      
            (ac2_mech.optional, AC_Games.ac2),     
        };

        public static void parser_ac1(HtmlNodeCollection tbodies) {
            int count = Math.Min(tbodies.Count, ParseMap_AC2.Length);
            for (int i = 0; i < count; i++) {
                var (model, game) = ParseMap_AC2[i];
                ParseTable(model, tbodies[i], game);
            }
        }

        /*public static void parser_ac2(HtmlNodeCollection tbodies) {
            for (int i = 0; i < tbodies.Count; i++) {
                switch (i) {
                    case 0:
                        ParseTable(ac2_mech.head, tbodies[i], AC_Games.ac2);
                        break;
                    case 1:
                        ParseTable(ac2_mech.head, tbodies[i], AC_Games.ac2_AA);
                        break;
                    case 2:
                        ParseTable(ac2_mech.core, tbodies[i], AC_Games.ac2);
                        break;
                    case 3:
                        ParseTable(ac2_mech.arms, tbodies[i], AC_Games.ac2);
                        break;
                    case 4:
                        ParseTable(ac2_mech.legs, tbodies[i], AC_Games.ac2);
                        break;
                    case 5:
                        ParseTable(ac2_mech.legs, tbodies[i], AC_Games.ac2_AA);
                        break;
                    case 6:
                        ParseTable(ac2_mech.booster, tbodies[i], AC_Games.ac2);
                        break;
                    case 7:
                        ParseTable(ac2_mech.fcs, tbodies[i], AC_Games.ac2);
                        break;
                    case 8:
                        ParseTable(ac2_mech.generator, tbodies[i], AC_Games.ac2);
                        break;
                    case 9:
                        ParseTable(ac2_mech.radiator, tbodies[i], AC_Games.ac2);
                        break;
                    case 10:
                        ParseTable(ac2_mech.inside, tbodies[i], AC_Games.ac2);
                        break;
                    case 11:
                        ParseTable(ac2_mech.inside, tbodies[i], AC_Games.ac2_AA);
                        break;
                    case 12:
                        ParseTable(ac2_mech.extension, tbodies[i], AC_Games.ac2);
                        break;
                    case 13:
                        ParseTable(ac2_mech.extension, tbodies[i], AC_Games.ac2_AA);
                        break;
                    case 14:
                        ParseTable(ac2_mech.backUnit, tbodies[i], AC_Games.ac2);
                        break;
                    case 15:
                        ParseTable(ac2_mech.backUnit, tbodies[i], AC_Games.ac2_AA);
                        break;
                    case 16:
                        ParseTable(ac2_mech.armR, tbodies[i], AC_Games.ac2);
                        break;
                    case 17:
                        ParseTable(ac2_mech.armR, tbodies[i], AC_Games.ac2_AA);
                        break;
                    case 18:
                        ParseTable(ac2_mech.armL, tbodies[i], AC_Games.ac2);
                        break;
                    case 19:
                        ParseTable(ac2_mech.armL, tbodies[i], AC_Games.ac2_AA);
                        break;
                    case 20:
                        ParseTable(ac2_mech.optional, tbodies[i], AC_Games.ac2);
                        break;
                    default:
                        break;
                }

            }
        }*/
    }
}
