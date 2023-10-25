using System;

namespace FlowTimeConverter.Logic
{
    public class TeachyTV(Selections.Version game, Selections.NConsole console, Selections.Method method) : Converter(game, console, method)
    {
        public double InsideTV { get; set; }
        private int OutsideTV { get; set; }
        protected double IntroTimerMS { get; set; }
        private double SeedLagMS => ReusableFunctions.FrameToMS(FPS, SeedLag);

        public TeachyTV SetOutSideTV(int frame)
        {
            OutsideTV = frame;
            return this;
        }
        public int GetIntroTimer() => IntroTimer;
        public double GetIntroToFrames() => ReusableFunctions.MSToFrame(FPS, IntroTimerMS);
        public double GetInsideTVFrames()
        {
            var Difference = TargetFrame - OutsideTV;
            double result = Difference / Constants.TVAccelerator + Constants.TVOffset;
            InsideTV = Math.Floor(result);
            return InsideTV;
        }

        public double GetRemainderFrames()
        {
            var Difference = TargetFrame - OutsideTV;
            return Difference % Constants.TVAccelerator;
        }
        public double GetOutSideTV()
        {
            return GetRemainderFrames() + OutsideTV - Constants.TVOffset;
        }
        public double GetTotalFrames()
        {
            return InsideTV + GetOutSideTV() + Delay;
        }

        public double GetTVMS()
        {
            var output = ReusableFunctions.FrameToMS(FPS, InsideTV);
            return Math.Floor(output);
        }

        public double GetTotalFrameMS()
        {
            var frameMS = ReusableFunctions.FrameToMS(FPS);
            var totalFrames = Math.Floor(GetTotalFrames());
            return frameMS * totalFrames;
        }

        public double GetTotalMS()
        {
            IntroTimerMS = IntroTimer + SeedLagMS;
            var framesMS = Math.Floor(GetTotalFrameMS());
            return framesMS + IntroTimerMS;
        }
    }
}
