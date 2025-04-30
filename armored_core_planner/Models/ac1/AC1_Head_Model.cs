
namespace armored_core_planner.Models.ac1 {
    public class AC1_Head_Model {
        public string PartId { get; set; }
        public int Price { get; set; }
        public float Weight { get; set; }
        public float EnDrain { get; set; }
        public int ArmorPoints { get; set; }
        public int DefShell { get; set; }
        public int DefEnergy { get; set; }
        public string ComputerType { get; set; }
        public string MapType { get; set; }
        public bool NoiseCanceler { get; set; }
        public bool BioSensor { get; set; }
        public bool RadarFunction { get; set; }
        public float RadarRange { get; set; }
        public string Unlock { get; set; }
        public string Notes { get; set; }

        public AC1_Head_Model() {
            PartId = "";
            Price = 0;
            Weight = 0;
            EnDrain = 0;
            ArmorPoints = 0;
            DefShell = 0;
            DefEnergy = 0;
            ComputerType = "";
            MapType = "";
            NoiseCanceler = false;
            BioSensor = false;
            RadarFunction = false;
            RadarRange = 0;
            Unlock = "Unknown";
            Notes = "";
        }
    }

}
