
using System;
using static FlowTimeConverter.Selections;

namespace FlowTimeConverter.Logic
{
    public class TeachyTV : Timer
    {
        public double IntroTimerMS => GetIntroToFrames();
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

        public double GetTotalFrames()
        {
            return InsideTV + OutsideTV + GetDelay();
        }

        public double GetTVMS()
        {
            return ReusableFunctions.FrameToMS(GetTotalFrames());
        }

        public double GetTotalFrameMS()
        {
            var frameMS = ReusableFunctions.FrameToMS(GetFPS());
            var totalFrames = Math.Floor(GetTotalFrames());
            return frameMS * totalFrames;
        }

        public double GetTotalMS()
        {
            var framesMS = Math.Floor(GetTotalFrameMS());
            return framesMS + IntroTimerMS;
        }
        private void GetTVSettings()
        {
            TVMethod = TVMethodDropDown.SelectedIndex switch
            {
                0 => FlowTimeConverter.Selections.Method.M124,
                1 => FlowTimeConverter.Selections.Method.SCO,
                2 => FlowTimeConverter.Selections.Method.SCI,
                _ => throw new NotImplementedException()
            };
        }
    }
}
