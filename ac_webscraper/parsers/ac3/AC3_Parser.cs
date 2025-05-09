using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ac_webscraper.models;
using HtmlAgilityPack;
using static ac_webscraper.parsers.TableParser;
using static ac_webscraper.models.Mech_Collection;

namespace ac_webscraper.parsers.ac3 {
    public class AC3_Parser {

        private static readonly (List<List<string>> model, AC_Games game)[] ParseMap_AC3 = new[] {
            (ac3_mech.head, AC_Games.ac3),
            (ac3_mech.head, AC_Games.ac3_portable),
            (ac3_mech.head, AC_Games.ac3_SL),
            (ac3_mech.head, AC_Games.ac3_SL_portable),
            (ac3_mech.core, AC_Games.ac3),
            (ac3_mech.core, AC_Games.ac3_SL),
            (ac3_mech.arms, AC_Games.ac3),
            (ac3_mech.arms, AC_Games.ac3_portable),
            (ac3_mech.arms, AC_Games.ac3_SL),
            (ac3_mech.arms, AC_Games.ac3_SL_portable),
            (ac3_mech.legs, AC_Games.ac3),
            (ac3_mech.legs, AC_Games.ac3_portable),
            (ac3_mech.legs, AC_Games.ac3_SL),
            (ac3_mech.legs, AC_Games.ac3_SL_portable),
            (ac3_mech.booster, AC_Games.ac3),
            (ac3_mech.booster, AC_Games.ac3_SL),
            (ac3_mech.booster, AC_Games.ac3_SL_portable),
            (ac3_mech.fcs, AC_Games.ac3),
            (ac3_mech.fcs, AC_Games.ac3_SL),
            (ac3_mech.generator, AC_Games.ac3),
            (ac3_mech.generator, AC_Games.ac3_SL),
            (ac3_mech.radiator, AC_Games.ac3),
            (ac3_mech.radiator, AC_Games.ac3_portable),
            (ac3_mech.radiator, AC_Games.ac3_SL),
            (ac3_mech.inside, AC_Games.ac3),
            (ac3_mech.inside, AC_Games.ac3_SL),
            (ac3_mech.extension, AC_Games.ac3),
            (ac3_mech.extension, AC_Games.ac3_SL),
            (ac3_mech.extension, AC_Games.ac3_SL_portable),
            (ac3_mech.backUnit, AC_Games.ac3),
            (ac3_mech.backUnit, AC_Games.ac3_portable),
            (ac3_mech.backUnit, AC_Games.ac3_SL),
            (ac3_mech.armR, AC_Games.ac3),
            (ac3_mech.armR, AC_Games.ac3_portable),
            (ac3_mech.armR, AC_Games.ac3_SL),
            (ac3_mech.armR, AC_Games.ac3_SL_portable),
            (ac3_mech.armL, AC_Games.ac3),
            (ac3_mech.armL, AC_Games.ac3_portable),
            (ac3_mech.armL, AC_Games.ac3_SL),
            (ac3_mech.optional, AC_Games.ac3),
            (ac3_mech.optional, AC_Games.ac3_SL),
        };

        public static void parser_ac1(HtmlNodeCollection tbodies) {
            int count = Math.Min(tbodies.Count, ParseMap_AC3.Length);
            for (int i = 0; i < count; i++) {
                var (model, game) = ParseMap_AC3[i];
                ParseTable(model, tbodies[i], game);
            }
        }
    }
}
