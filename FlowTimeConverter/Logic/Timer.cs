using FlowTimeConverter.Logic;
using System;
using Newtonsoft.Json;

namespace FlowTimeConverter
{
    public class Timer(Selections.Version game, Selections.NConsole console, Selections.Method method) : Converter(game, console, method)
    {
        private double FlatMS { get; set; }

        public void SetIntroTimerMS() => IntroTimerMS = IntroTimer + SeedLagMS;
        public void AdjustIntroMS() 
        {
            IntroTimerMS += AdjustSeedHit();
        }
        public double CalculateFlatMS()
        {
            var delayDifference = TargetFrame + GetDelay();
            FlatMS = ReusableFunctions.FrameToMS(FPS, delayDifference);
            return FlatMS;
        }
        public double[] FlowtimerMSTotal() => new double[] { FlatMS + IntroTimerMS, IntroTimer };
        public int AdjustFrameHit() => TargetFrame - TargetFrameHit;
        public double AdjustFrameHitMS() => ReusableFunctions.FrameToMS(FPS, AdjustFrameHit());
        public double AdjustSeedHit() => IntroTimer - IntroTimerHit;
        public double ReturnFinalIntro() => IntroTimerMS - SeedLagMS;
        public double RecalculateFlatMS()
        {
            var adjustedPureMS = AdjustFrameHitMS();
            FlatMS = Math.Round(FlatMS) + adjustedPureMS;
            return FlatMS;
        }
        public double ReturnNewTotal() => FlatMS + Math.Round(IntroTimerMS);
    }
}