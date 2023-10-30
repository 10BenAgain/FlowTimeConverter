using System;

namespace FlowTimeConverter.Logic
{
    public class TeachyTV(Selections.Version game, Selections.NConsole console, Selections.Method method) : Converter(game, console, method)
    {
        private double InsideTV { get; set; }
        private int OutsideTV { get; set; }
        private double FlatMS { get; set; }

        public TeachyTV SetOutSideTV(int frame)
        {
            OutsideTV = frame;
            return this;
        }
        public TeachyTV OverrideFlatMS(double val)
        {
            FlatMS = val;
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
            FlatMS = framesMS + IntroTimerMS;
            return framesMS + IntroTimerMS;
        }

        public double AdjustedTV() => TargetFrame - TargetFrameHit;
        
        public double[] GetAdjustedValues()
        {
            var second = AdjustedTV() / Constants.TVAccelerator;
            var adjustOut = (int)Math.Round(AdjustedTV()) % Constants.TVAccelerator;

            if (adjustOut >= 156)
            {
                adjustOut -= Constants.TVAccelerator;
                second++;
            }

            if (adjustOut < -156)
            {
                adjustOut += Constants.TVAccelerator;
                second--;
            }

            var total = adjustOut + second;
            var adjustTVBy = second >= 0 ? Math.Floor(second) : Math.Ceiling(second); // adjusttvby
            var adjustTotalBy = adjustOut + adjustTVBy; //adjusttotalby

            var msout = ReusableFunctions.FrameToMS(FPS, adjustTotalBy); // adjusttvmsby
            var tvmsout = ReusableFunctions.FrameToMS(FPS, adjustTVBy); // adjusttotalmsby

            var adjustedTVMS = tvmsout + GetTVMS(); // tvms
            var adjustedTotalMS = msout + FlatMS; // totalms

            return new double[] { adjustTVBy, adjustTotalBy, msout, tvmsout, adjustedTVMS, adjustedTotalMS };
        }
    }
}
