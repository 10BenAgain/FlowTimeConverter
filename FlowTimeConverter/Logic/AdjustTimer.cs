
using System;

namespace FlowTimeConverter.Logic
{
    public class AdjustTimer
    {
        public int TargetIntroMS { get; set; }
        public int TargetIntroHitMS { get; set; }
        public int TargetFrame { get; set; }
        public int TargetFrameHit { get; set; }

        public double FPS { get; set; }
        public double SeedLag { get; set; }
        public int Delay { get; set; }
        private double InitialMS 
        { 
            get 
            { 
                return ReusableFunctions.TotalTimerMS(FPS, SeedLag, TargetFrame, Delay, TargetIntroMS); 
            } 
        }

        public AdjustTimer(int targetFrame, int TargetIntro, int FrameHit, int IntroHit,
            double fps, double seedLag, int delay)
        {
            TargetIntroMS = TargetIntro;
            TargetIntroHitMS = IntroHit;
            TargetFrame = targetFrame;
            TargetFrameHit = FrameHit;

            FPS = fps;
            SeedLag = seedLag;
            Delay = delay;
        }
        public double IntroMSAdjust() => TargetIntroMS - TargetIntroHitMS;
        public int AdvancesAdjust() => TargetFrame - TargetFrameHit;
        private double AdvancesAdjustMS()
        {
            var newTotalMs = ReusableFunctions
                .TotalTimerMS(FPS, SeedLag, TargetFrameHit, 
                              Delay, TargetIntroHitMS);

            return InitialMS - newTotalMs;
        }

        public string UpdatedFlowTimer()
        {
            var final = Math.Round(InitialMS) + AdvancesAdjustMS();
            return $"{Math.Round(final)}/{TargetIntroMS + IntroMSAdjust()}";
        }

    }
}
