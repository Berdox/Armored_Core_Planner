using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ac_webscraper.models.ac1;
using ac_webscraper.models.ac2;
using ac_webscraper.models.ac3;
using ac_webscraper.models.ac4;

namespace ac_webscraper.models {
    public static class Mech_Collection {
        public static AC1_Mech ac1_mech { get; set; }
        public static AC2_Mech ac2_mech { get; set; }
        public static AC3_Mech ac3_mech { get; set; }
        public static AC4_Mech ac4_mech { get; set; }

        static Mech_Collection() {
            ac1_mech = new AC1_Mech();
            ac2_mech = new AC2_Mech();
            ac3_mech = new AC3_Mech();
            ac4_mech = new AC4_Mech();
        }
    }
}
