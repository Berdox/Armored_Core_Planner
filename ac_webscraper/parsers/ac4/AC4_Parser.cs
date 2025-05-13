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

namespace ac_webscraper.parsers.ac4 {
    public class AC4_Parser {
        private static readonly (List<(Image image, List<string>)> model, AC_Games game)[] ParseMap_AC4 = new[] {
            (ac4_mech.head, AC_Games.ac4),
            (ac4_mech.head, AC_Games.ac4_FA),
            (ac4_mech.core, AC_Games.ac4),
            (ac4_mech.core, AC_Games.ac4_FA),
            (ac4_mech.arms, AC_Games.ac4),
            (ac4_mech.arms, AC_Games.ac4_FA),
            (ac4_mech.legs, AC_Games.ac4),
            (ac4_mech.legs, AC_Games.ac4_FA),
            (ac4_mech.fcs, AC_Games.ac4),
            (ac4_mech.fcs, AC_Games.ac4_FA),
            (ac4_mech.generator, AC_Games.ac4),
            (ac4_mech.generator, AC_Games.ac4_FA),
            (ac4_mech.main_booster, AC_Games.ac4),
            (ac4_mech.main_booster, AC_Games.ac4_FA),
            (ac4_mech.back_booster, AC_Games.ac4),
            (ac4_mech.back_booster, AC_Games.ac4_FA),
            (ac4_mech.side_booster, AC_Games.ac4),
            (ac4_mech.side_booster, AC_Games.ac4_FA),
            (ac4_mech.over_booster, AC_Games.ac4),
            (ac4_mech.over_booster, AC_Games.ac4_FA),
            (ac4_mech.arm_weapons, AC_Games.ac4),
            (ac4_mech.arm_weapons, AC_Games.ac4_FA),
            (ac4_mech.back_weapons, AC_Games.ac4),
            (ac4_mech.shoulder, AC_Games.ac4),
            (ac4_mech.hanger_weapons, AC_Games.ac4),
        };

        public static void parser_ac1(HtmlNodeCollection tbodies) {
            int count = Math.Min(tbodies.Count, ParseMap_AC4.Length);
            for (int i = 0; i < count; i++) {
                var (model, game) = ParseMap_AC4[i];
                ParseTable(model, tbodies[i], game);
            }
        }
    }
}
