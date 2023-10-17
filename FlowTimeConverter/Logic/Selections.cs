
namespace FlowTimeConverter
{
    public class Selections
    {
        public enum NConsole : byte
        {
            GBA = 1,
            NDS,
            N3DS,
            O3DS,
            FPS60
        }

        public enum Version : byte
        {
            FR10 = 1,
            FR11,
            LG,
            RS,
            Emerald,
            USUM
        }
        public enum Method : byte
        {
            M124 = 1,
            SCO,
            SCI,
            ID
        }
    }
}
