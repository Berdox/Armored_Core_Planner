using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SixLabors.ImageSharp;

namespace ac_webscraper.models.ac6 {
    public class AC6_Mech {
        public List<(Image image, List<string>)> arm_weapons { get; set; }
        public List<(Image image, List<string>)> arm_weapon_L_only { get; set; }
        public List<(Image image, List<string>)> back_unit { get; set; }
        public List<(Image image, List<string>)> back_unit_L_only { get; set; }
        public List<(Image image, List<string>)> head { get; set; }
        public List<(Image image, List<string>)> core { get; set; }
        public List<(Image image, List<string>)> arms { get; set; }
        public List<(Image image, List<string>)> legs { get; set; }
        public List<(Image image, List<string>)> booster { get; set; }
        public List<(Image image, List<string>)> fcs { get; set; }
        public List<(Image image, List<string>)> generator { get; set; }
        public List<(Image image, List<string>)> expansions { get; set; }

        public AC6_Mech() {
            arm_weapons = [];
            arm_weapon_L_only = [];
            back_unit = [];
            back_unit_L_only = [];
            head = [];
            core = [];
            arms = [];
            legs = [];
            booster = [];
            fcs = [];
            generator = [];
            expansions = [];
        }
    }
}
