
using System;

namespace FlowTimeConverter.Logic
{
    public class TeachyTV : Timer
    {
        public double InsideTV { get; set; }
        private int OutsideTV { get; set; }
        public TeachyTV(Selections.Version game, Selections.NConsole console, Selections.Method method) 
            : base(game, console, method)
        {
        }
        public TeachyTV SetOutSideTV(int frame)
        {
            OutsideTV = frame;
            return this;
        }
        public double GetIntroToFrames() => ReusableFunctions.MSToFrame(GetFPS(), IntroTimerMS);
        public double GetInsideTVFrames()
        {
            var Difference = GetTargetFrame() - OutsideTV;
            double result = Difference / Constants.TVAccelerator + Constants.TVOffset;
            InsideTV = Math.Floor(result);
            return InsideTV;
        }

        public double GetRemainderFrames()
        {
            var Difference = GetTargetFrame() - OutsideTV;
            return Difference % Constants.TVAccelerator;
        }
        public double GetOutSideTV()
        {
            return GetRemainderFrames() + OutsideTV - Constants.TVOffset;
        }
        public double GetTotalFrames()
        {
            return InsideTV + GetOutSideTV() + GetDelay();
        }

        public double GetTVMS()
        {
            var output = ReusableFunctions.FrameToMS(GetFPS(), InsideTV);
            return Math.Floor(output);
        }

        public double GetTotalFrameMS()
        {
            var frameMS = ReusableFunctions.FrameToMS(GetFPS());
            var totalFrames = Math.Floor(GetTotalFrames());
            return frameMS * totalFrames;
        }

        public double GetTotalMS()
        {
            SetSeedLagMS();
            SetIntroTimerMS();
            var framesMS = Math.Floor(GetTotalFrameMS());
            return framesMS + IntroTimerMS;
        }
    }
}
