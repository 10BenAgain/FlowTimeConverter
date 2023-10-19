using FlowTimeConverter.Logic;
using System;
using System.Windows.Forms;

namespace FlowTimeConverter
{
    public class Timer(Selections.Version game, Selections.NConsole console, Selections.Method method)
    {
        private byte NConsole { get; set; } = (byte)console;
        private byte Game { get; set; } = (byte)game;
        private byte Method { get; set; } = (byte)method;

        private int Delay { get; set; } = method switch
        {
            Selections.Method.M124 => Constants.M124,
            Selections.Method.SCI => Constants.MethodSCI,
            Selections.Method.SCO => Constants.MethodSCO,
            _ => 0,
        };
        public int SeedLag { get; set; } = game switch
        {
            Selections.Version.FR10 => Constants.FR10,
            Selections.Version.FR11 => Constants.FR11,
            Selections.Version.LG => Constants.LG,
            _ => 0,
        };
        private double FPS { get; set; } = console switch
        {
            Selections.NConsole.GBA => Constants.GBAFPS,
            Selections.NConsole.NDS => Constants.NDSFPS,
            Selections.NConsole.N3DS => Constants.NEW3DS,
            Selections.NConsole.O3DS => Constants.OLD3DS,
            Selections.NConsole.FPS60 => Constants.FPS60,
            _ => 0,
        };
        private int TargetFrame { get; set; }
        private int TargetFrameHit { get; set; }
        private int IntroTimer { get; set; }
        private int IntroTimerHit { get; set; }
        private double IntroTimerMS { get; set; }
        private double SeedLagMS { get; set; }
        private double FlatMS { get; set; }

        public Timer SetTargetFrame(int frame)
        {
            TargetFrame = frame;
            return this;
        }
        public Timer SetIntroTimer(int frame)
        {
            IntroTimer = frame;
            return this;
        }
        public Timer SetSeedLagMS()
        {
            SeedLagMS = ReusableFunctions.FrameToMS(FPS, SeedLag);
            return this;
        }
        public Timer SetIntroTimerMS()
        {
            IntroTimerMS = IntroTimer + SeedLagMS;
            return this;
        }
        public Timer SetFrameHit(int frame)
        {
            TargetFrameHit = frame;
            return this;
        }
        public Timer SetIntroHit(int frame)
        {
            IntroTimerHit = frame;
            return this;
        }
        public int GetDelay()
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
        public int GetSeedLag() => SeedLag;
        public double GetFPS() => FPS;
        public double GetFlatMS() => FlatMS;
        public double CalculateFlatMS()
        {
            var delayDifference = TargetFrame + GetDelay();
            FlatMS = ReusableFunctions.FrameToMS(FPS, delayDifference);
            return FlatMS;
        }
        public double CalculateTotalFrames()
        {
            return FlatMS + IntroTimerMS;
        }
        public double[] FlowtimerMSTotal()
        {
            var TotalFrames = CalculateTotalFrames();
            return new double[] { TotalFrames, IntroTimer };
        }
        // adjustby
        public int AdjustFrameHit()
        {
            return TargetFrame - TargetFrameHit;
        }
        //adjustbyms
        public double AdjustFrameHitMS()
        {
            return ReusableFunctions.FrameToMS(FPS, AdjustFrameHit());
        }
        public double AdjustSeedHit()
        {
            //Very redundant?
            var seedHitlag = IntroTimerHit + ReusableFunctions.FrameToMS(FPS, SeedLag);
            var introTimerLag = IntroTimer + ReusableFunctions.FrameToMS(FPS, SeedLag);
            return introTimerLag - seedHitlag;
        }

        public Timer AdjustIntroMS()
        {
            IntroTimerMS += AdjustSeedHit();
            return this;
        }
        public double AdjustIntroTimerMS()
        {
            return IntroTimerMS;
        }
        public double ReturnFinalIntro()
        {
            var introNoLag = AdjustIntroTimerMS();
            return introNoLag - SeedLagMS;
        }
        public double RecalculateFlatMS()
        {
            var adjustedPureMS = AdjustFrameHitMS();
            FlatMS = Math.Round(FlatMS) + adjustedPureMS;
            return FlatMS;
        }
        //intropurems
        public double ReturnNewTotal()
        {
            return FlatMS + Math.Round(IntroTimerMS);
        }
    }
}