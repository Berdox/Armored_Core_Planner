using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ac_webscraper.models.ac4 {
    public class AC4_Mech {
        public List<List<string>> head { get; set; }
        public List<List<string>> core { get; set; }
        public List<List<string>> arms { get; set; }
        public List<List<string>> legs { get; set; }
        public List<List<string>> fcs { get; set; }
        public List<List<string>> generator { get; set; }
        public List<List<string>> main_booster { get; set; }
        public List<List<string>> back_booster { get; set; }
        public List<List<string>> side_booster { get; set; }
        public List<List<string>> over_booster { get; set; }
        public List<List<string>> arm_weapons { get; set; }
        public List<List<string>> back_weapons { get; set; }
        public List<List<string>> shoulder { get; set; }
        public List<List<string>> hanger_weapons { get; set; }

        public AC4_Mech() {
            head = [];
            core = [];
            arms = [];
            legs = [];
            fcs = [];
            generator = [];
            main_booster = [];
            back_booster = [];
            side_booster = [];
            over_booster = [];
            arm_weapons = [];
            back_weapons = [];
            shoulder = [];
            hanger_weapons = [];
        }
    }
}
