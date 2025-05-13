using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SixLabors.ImageSharp;

namespace ac_webscraper.models.ac3 {
    public class AC3_Mech {
        public List<(Image image, List<string>)> head { get; set; }
        public List<(Image image, List<string>)> core { get; set; }
        public List<(Image image, List<string>)> arms { get; set; }
        public List<(Image image, List<string>)> legs { get; set; }
        public List<(Image image, List<string>)> booster { get; set; }
        public List<(Image image, List<string>)> fcs { get; set; }
        public List<(Image image, List<string>)> generator { get; set; }
        public List<(Image image, List<string>)> radiator { get; set; }
        public List<(Image image, List<string>)> inside { get; set; }
        public List<(Image image, List<string>)> extension { get; set; }
        public List<(Image image, List<string>)> backUnit { get; set; }
        public List<(Image image, List<string>)> armR { get; set; }
        public List<(Image image, List<string>)> armL { get; set; }
        public List<(Image image, List<string>)> optional { get; set; }

        public AC3_Mech() {
            head = [];
            core = [];
            arms = [];
            legs = [];
            booster = [];
            fcs = [];
            generator = [];
            radiator = [];
            inside = [];
            extension = [];
            backUnit = [];
            armR = [];
            armL = [];
            optional = [];
        }
    }
}
