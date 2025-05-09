using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ac_webscraper.models.ac1 {
    public class AC1_Mech {
        public List<List<string>> head { get; set; }
        public List<List<string>> core { get; set; }
        public List<List<string>> arms { get; set; }
        public List<List<string>> legs { get; set; }
        public List<List<string>> booster { get; set; }
        public List<List<string>> fcs { get; set; }
        public List<List<string>> generator { get; set; }
        public List<List<string>> backUnit { get; set; }
        public List<List<string>> armsR { get; set; }
        public List<List<string>> armsL { get; set; }
        public List<List<string>> optional { get; set; }

        public AC1_Mech() {
            head = [];
            core = [];
            arms = [];
            legs = [];
            booster = [];
            fcs = [];
            generator = [];
            backUnit = [];
            armsR = [];
            armsL = [];
            optional = [];
        }
    }
}
