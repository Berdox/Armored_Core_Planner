using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HtmlAgilityPack;
using armored_core_planner.Models.ac1;
using static ac_webscraper.parsers.TableParser;
using static ac_webscraper.models.Mech_Collection;
using ac_webscraper.models;

namespace ac_webscraper.parsers.ac1 {
    public static class AC1_Parser {

        private static readonly (List<List<string>> model, AC_Games game)[] ParseMap_AC1 = new[] {
            (ac1_mech.head, AC_Games.ac1),      
            (ac1_mech.head, AC_Games.ac1_PP),    
            (ac1_mech.head, AC_Games.ac1_MOA),
            (ac1_mech.core, AC_Games.ac1),      
            (ac1_mech.core, AC_Games.ac1_PP),    
            (ac1_mech.core, AC_Games.ac1_MOA),
            (ac1_mech.arms, AC_Games.ac1),      
            (ac1_mech.arms, AC_Games.ac1_PP),    
            (ac1_mech.arms, AC_Games.ac1_MOA),
            (ac1_mech.legs, AC_Games.ac1),
            (ac1_mech.legs, AC_Games.ac1_PP),
            (ac1_mech.legs, AC_Games.ac1_MOA),
            (ac1_mech.booster, AC_Games.ac1),
            (ac1_mech.booster, AC_Games.ac1_PP),
            (ac1_mech.booster, AC_Games.ac1_MOA),
            (ac1_mech.fcs, AC_Games.ac1),
            (ac1_mech.fcs, AC_Games.ac1_PP),
            (ac1_mech.fcs, AC_Games.ac1_MOA),
            (ac1_mech.generator, AC_Games.ac1),
            (ac1_mech.generator, AC_Games.ac1_PP),
            (ac1_mech.backUnit, AC_Games.ac1),
            (ac1_mech.backUnit, AC_Games.ac1_PP),
            (ac1_mech.backUnit, AC_Games.ac1_MOA),
            (ac1_mech.armsR, AC_Games.ac1),
            (ac1_mech.armsR, AC_Games.ac1_PP),
            (ac1_mech.armsR, AC_Games.ac1_MOA),
            (ac1_mech.armsL, AC_Games.ac1),
            (ac1_mech.armsL, AC_Games.ac1_MOA),
            (ac1_mech.optional, AC_Games.ac1),
            (ac1_mech.optional, AC_Games.ac1_PP),
            (ac1_mech.optional, AC_Games.ac1_MOA)
        };

        public static void parser_ac1(HtmlNodeCollection tbodies) {
            int count = Math.Min(tbodies.Count, ParseMap_AC1.Length);
            for (int i = 0; i < count; i++) {
                var (model, game) = ParseMap_AC1[i];
                ParseTable(model, tbodies[i], game);
            }
        }

        /*public static void parser_ac1(HtmlNodeCollection tbodies) {
            for (int i = 0; i < tbodies.Count; i++) {
                switch (i) {
                    case 0:
                        ParseTable(ac1_mech.head, tbodies[i], AC_Games.ac1);
                        break;
                    case 1:
                        ParseTable(ac1_mech.head, tbodies[i], AC_Games.ac1_PP);
                        break;
                    case 2:
                        ParseTable(ac1_mech.head, tbodies[i], AC_Games.ac1_MOA);
                        break;
                    case 3:
                        ParseTable(ac1_mech.core, tbodies[i], AC_Games.ac1);
                        break;
                    case 4:
                        ParseTable(ac1_mech.core, tbodies[i], AC_Games.ac1_PP);
                        break;
                    case 5:
                        ParseTable(ac1_mech.core, tbodies[i], AC_Games.ac1_MOA);
                        break;
                    case 6:
                        ParseTable(ac1_mech.arms, tbodies[i], AC_Games.ac1);
                        break;
                    case 7:
                        ParseTable(ac1_mech.arms, tbodies[i], AC_Games.ac1_PP);
                        break;
                    case 8:
                        ParseTable(ac1_mech.arms, tbodies[i], AC_Games.ac1_MOA);
                        break;
                    case 9:
                        ParseTable(ac1_mech.legs, tbodies[i], AC_Games.ac1);
                        break;
                    case 10:
                        ParseTable(ac1_mech.legs, tbodies[i], AC_Games.ac1_PP);
                        break;
                    case 11:
                        ParseTable(ac1_mech.legs, tbodies[i], AC_Games.ac1_MOA);
                        break;
                    case 12:
                        ParseTable(ac1_mech.booster, tbodies[i], AC_Games.ac1);
                        break;
                    case 13:
                        ParseTable(ac1_mech.booster, tbodies[i], AC_Games.ac1_PP);
                        break;
                    case 14:
                        ParseTable(ac1_mech.booster, tbodies[i], AC_Games.ac1_MOA);
                        break;
                    case 15:
                        ParseTable(ac1_mech.fcs, tbodies[i], AC_Games.ac1);
                        break;
                    case 16:
                        ParseTable(ac1_mech.fcs, tbodies[i], AC_Games.ac1_PP);
                        break;
                    case 17:
                        ParseTable(ac1_mech.fcs, tbodies[i], AC_Games.ac1_MOA);
                        break;
                    case 18:
                        ParseTable(ac1_mech.generator, tbodies[i], AC_Games.ac1);
                        break;
                    case 19:
                        ParseTable(ac1_mech.generator, tbodies[i], AC_Games.ac1_PP);
                        break;
                    case 20:
                        ParseTable(ac1_mech.backUnit, tbodies[i], AC_Games.ac1);
                        break;
                    case 21:
                        ParseTable(ac1_mech.backUnit, tbodies[i], AC_Games.ac1_PP);
                        break;
                    case 22:
                        ParseTable(ac1_mech.backUnit, tbodies[i], AC_Games.ac1_MOA);
                        break;
                    case 23:
                        ParseTable(ac1_mech.armsR, tbodies[i], AC_Games.ac1);
                        break;
                    case 24:
                        ParseTable(ac1_mech.armsR, tbodies[i], AC_Games.ac1_PP);
                        break;
                    case 25:
                        ParseTable(ac1_mech.armsR, tbodies[i], AC_Games.ac1_MOA);
                        break;
                    case 26:
                        ParseTable(ac1_mech.armsL, tbodies[i], AC_Games.ac1);
                        break;
                    case 27:
                        ParseTable(ac1_mech.armsL, tbodies[i], AC_Games.ac1_MOA);
                        break;
                    case 28:
                        ParseTable(ac1_mech.optional, tbodies[i], AC_Games.ac1);
                        break;
                    case 29:
                        ParseTable(ac1_mech.optional, tbodies[i], AC_Games.ac1_PP);
                        break;
                    case 30:
                        ParseTable(ac1_mech.optional, tbodies[i], AC_Games.ac1_MOA);
                        break;
                    default:
                        break;
                }

            }
        }*/
    }
}
