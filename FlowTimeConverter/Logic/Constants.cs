
namespace FlowTimeConverter
{
    public class Constants
    {
        const double GBAFPS = 59.7275; // Frame Rate for GBA
        const double NDSFPS = 59.6555;  // Frame Rate for NDS
        const double NEW3DS = 59.8261;
        const double OLD3DS = 59.8261;
        const int FPS60 = 60;

        const int FR10 = 121; // Intro change for game version FR 1.0
        const int FR11 = 120; // Intro change for game version FR 1.1
        const int LG = 114; // Intro change for game version LG

        const int M124 = -20; // Delay for Methods 1 / 2 / 4
        const int MethodSCO = -261; // Delay for Sweet Scent Outdoors
        const int MethodSCI = -268; // Delay for Sweety Scent Indoors
        const int IDRNG = 0;

        const int TVAccelerator = 313; // TV Frame eccelerator offset
        public static double GBARate => GBAFPS;
        public static double NDSRate => NDSFPS;
        public static double NEW3DSRate => NEW3DS;
        public static double OLD3DSRate => OLD3DS;
        public static double SixtyFPS => FPS60;
        public static int FireRed10 => FR10;
        public static int FireRed11 => FR11;
        public static int LeafGreen => LG;
        public static int Method124 => M124;
        public static int SweetScentOut => MethodSCO;
        public static int SweetScentIn => MethodSCI;
        public static int IDMethod => IDRNG;
    }
}
