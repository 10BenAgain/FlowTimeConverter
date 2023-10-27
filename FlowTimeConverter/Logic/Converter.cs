
namespace FlowTimeConverter.Logic
{
    public abstract class Converter(Selections.Version game, Selections.NConsole console, Selections.Method method)
    {
        protected byte NConsole { get; set; } = (byte)console;
        protected byte Game { get; set; } = (byte)game;
        protected byte Method { get; set; } = (byte)method;
        protected int TargetFrame { get; set; }
        protected int TargetFrameHit { get; set; }
        protected int IntroTimer { get; set; }
        protected double IntroTimerMS { get; set; }
        protected int IntroTimerHit { get; set; }
        protected int Delay { get; set; } = method switch
        {
            Selections.Method.M124 => Constants.M124,
            Selections.Method.SCI => Constants.MethodSCI,
            Selections.Method.SCO => Constants.MethodSCO,
            _ => 0,
        };


        protected int SeedLag { get; set; } = game switch
        {
            Selections.Version.FR10 => Constants.FR10,
            Selections.Version.FR11 => Constants.FR11,
            Selections.Version.LG => Constants.LG,
            _ => 0,
        };
        protected double SeedLagMS => ReusableFunctions.FrameToMS(FPS, SeedLag);
        protected double FPS { get; set; } = console switch
        {
            Selections.NConsole.GBA => Constants.GBAFPS,
            Selections.NConsole.NDS => Constants.NDSFPS,
            Selections.NConsole.N3DS => Constants.NEW3DS,
            Selections.NConsole.O3DS => Constants.OLD3DS,
            Selections.NConsole.FPS60 => Constants.FPS60,
            _ => 0,
        };
        public void SetDelay(int delay) => Delay = delay;

        public Converter SetTargetFrame(int frame)
        {
            TargetFrame = frame;
            return this;
        }
        public Converter SetIntroTimer(int frame)
        {
            IntroTimer = frame;
            return this;
        }
        public Converter SetFrameHit(int frame)
        {
            TargetFrameHit = frame;
            return this;
        }
        public Converter SetIntroHit(int frame)
        {
            IntroTimerHit = frame;
            return this;
        }
        public virtual int GetDelay()
        {
            if (Method != 4)
                return Delay;
            else
                return Game switch
                {
                    // Values from Blisy's site for respective delay times
                    1 or 2 or 3 => -249,
                    4 => -75,
                    5 => -50,
                    _ => -20,
                };
        }
    }
}
