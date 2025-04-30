namespace armored_core_planner.Models.ac1 {
    public class AC1_Core_Model {
        public string PartId { get; set; }
        public int Price { get; set; }
        public string CoreType { get; set; }
        public float Weight { get; set; }
        public float EnDrain { get; set; }
        public int ArmorPoints { get; set; }
        public int DefShell { get; set; }
        public int DefEnergy { get; set; }
        public int MaxWeight { get; set; }
        public int AntiMissileResponse { get; set; }
        public int AntiMissileAngle { get; set; }
        public int ExtensionSlots { get; set; }
        public string Unlock { get; set; }
        public string Notes { get; set; }

        public AC1_Core_Model() {
            PartId = "";
            Price = 0;
            CoreType = "";
            Weight = 0;
            EnDrain = 0;
            ArmorPoints = 0;
            DefShell = 0;
            DefEnergy = 0;
            MaxWeight = 0;
            AntiMissileResponse = 0;
            AntiMissileAngle = 0;
            ExtensionSlots = 0;
            Unlock = "Unknown";
            Notes = "";
        }
    }
}
