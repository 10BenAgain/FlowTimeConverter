using FlowTimeConverter.Logic;
using System;

namespace FlowTimeConverter
{
    public class Timer 
    {
        private byte NConsole { get; set; } // Might use later?
        private byte Game { get; set; }
        private byte Method { get; set; }
        public double FPS { get; set; }
        public int TargetFrame { get; set; }
        public int IntroTimer { get; set; }
        private int Delay { get; set; }
        public int SeedLag { get; set; }

        public Timer(Selections.Version game, Selections.NConsole console, Selections.Method method)
        {
            Game = (byte)game;
            Method = (byte)method;
            NConsole = (byte)console;

            SeedLag = game switch
            {
                Selections.Version.FR10 => Constants.FireRed10,
                Selections.Version.FR11 => Constants.FireRed11,
                Selections.Version.LG => Constants.LeafGreen,
                _ => 0,
            };

            Delay = method switch
            {
                Selections.Method.M124 => Constants.Method124,
                Selections.Method.SCI => Constants.SweetScentIn,
                Selections.Method.SCO => Constants.SweetScentOut,
                _ => 0,
            };

            FPS = console switch
            {
                Selections.NConsole.GBA => Constants.GBARate,
                Selections.NConsole.NDS => Constants.NDSRate,
                Selections.NConsole.N3DS => Constants.NEW3DSRate,
                Selections.NConsole.O3DS => Constants.OLD3DSRate,
                Selections.NConsole.FPS60 => Constants.SixtyFPS,
                _ => 0,
            };
        }
        public void SetTargetFrame(int frame)
        {
            try
            {
                if (frame > 0)
                    TargetFrame = frame;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void SetIntroTimer(int frame)
        {
            try
            {
                if (frame > 0)
                    IntroTimer = frame;
            }
            catch (Exception)
            {
                throw;
            }
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

        /// <summary>
        ///  Returns FlatMS, TotalTimerMS, and IntroTimerMS as a double array
        /// </summary>
        /// <returns></returns>
        public double[] GetFlowTimerValues()
        {
            var FlatMS = ReusableFunctions.FlatMS(FPS, TargetFrame, Delay);
            var TotalTimerMS = ReusableFunctions.TotalTimerMS(FPS, SeedLag, TargetFrame, Delay, IntroTimer);

            return new double[] { FlatMS, TotalTimerMS, Convert.ToDouble(IntroTimer) };
        }

        /// <summary>
        /// Returns FlatMS, TotalTimerMS, and IntroTimerMS as a string array
        /// </summary>
        /// <returns></returns>
        public string[] GetStringValues()
        {
            var values = GetFlowTimerValues();
            var output = new string[3];

            for (int i = 0; i < 3; i++)
            {
                var round = Math.Round(values[i]);
                output[i] = round.ToString();
            }
            return output;
        }
    }
}