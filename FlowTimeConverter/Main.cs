using FlowTimeConverter.Logic;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace FlowTimeConverter
{
    public sealed partial class FlowtimerConverter : Form
    {
        public Timer InitialConverter { get; set; }
        public Selections.NConsole NConsole { get; set; }
        public Selections.Version Version { get; set; }
        public Selections.Method Method { get; set; }

        public Selections.NConsole TVConsole { get; set; }
        public Selections.Version TVVersion { get; set; }
        public Selections.Method TVMethod { get; set; }

        public FlowtimerConverter()
        {
            InitializeComponent();
        }
        private void FlowtimerConverter_Load_1(object sender, EventArgs e)
        {
            ConsoleDropDown.SelectedItem = "GBA";
            MethodDropDown.SelectedItem = "Method 1/2/4";
            GameDropDown.SelectedItem = "FireRed 1.0";
            EncounterAdvancesBox.Value = 1400;

            TVGameDropDown.SelectedItem = "FireRed 1.0";
            TVConsoleDropDown.SelectedItem = "GBA";
            TVMethodDropDown.SelectedItem = "Method 1/2/4";
            TVIntroTimerMSInitBox.Value = 35000;
            TVTargetFrameInitBox.Value = 45000;
            TVFramesOutBox.Value = 1400;
        }
        private void GetConverterSettings()
        {
            Version = GameDropDown.SelectedIndex switch
            {
                0 => FlowTimeConverter.Selections.Version.FR10,
                1 => FlowTimeConverter.Selections.Version.FR11,
                2 => FlowTimeConverter.Selections.Version.LG,
                3 => FlowTimeConverter.Selections.Version.RS,
                4 => FlowTimeConverter.Selections.Version.Emerald,
                5 => FlowTimeConverter.Selections.Version.USUM,
                _ => throw new NotImplementedException(),
            };

            NConsole = ConsoleDropDown.SelectedIndex switch
            {
                0 => FlowTimeConverter.Selections.NConsole.GBA,
                1 => FlowTimeConverter.Selections.NConsole.NDS,
                2 => FlowTimeConverter.Selections.NConsole.N3DS,
                3 => FlowTimeConverter.Selections.NConsole.O3DS,
                4 => FlowTimeConverter.Selections.NConsole.FPS60,
                _ => throw new NotImplementedException(),
            };

            Method = MethodDropDown.SelectedIndex switch
            {
                0 => FlowTimeConverter.Selections.Method.M124,
                1 => FlowTimeConverter.Selections.Method.SCO,
                2 => FlowTimeConverter.Selections.Method.SCI,
                3 => FlowTimeConverter.Selections.Method.ID,
                _ => throw new NotImplementedException(),
            };
        }
        private void GetTVSettings()
        {
            TVVersion = TVGameDropDown.SelectedIndex switch
            {
                0 => FlowTimeConverter.Selections.Version.FR10,
                1 => FlowTimeConverter.Selections.Version.FR11,
                2 => FlowTimeConverter.Selections.Version.LG,
                _ => throw new NotImplementedException()
            };

            TVConsole = TVConsoleDropDown.SelectedIndex switch
            {
                0 => FlowTimeConverter.Selections.NConsole.GBA,
                1 => FlowTimeConverter.Selections.NConsole.NDS,
                _ => throw new NotImplementedException()
            };

            TVMethod = TVMethodDropDown.SelectedIndex switch
            {
                0 => FlowTimeConverter.Selections.Method.M124,
                1 => FlowTimeConverter.Selections.Method.SCO,
                2 => FlowTimeConverter.Selections.Method.SCI,
                _ => throw new NotImplementedException()
            };
        }

        private void CalculateInitialButton_Click(object sender, EventArgs e)
        {
            GetConverterSettings();
            var timer = new Timer(Version, NConsole, Method);
            var userInput = ReusableFunctions.ConvertDecimal(GetInitialUserInput());

            timer
                .SetIntroTimer(userInput[0])
                .SetTargetFrame(userInput[1])
                .SetSeedLagMS()
                .SetIntroTimerMS();

            DelayBox.Value = timer.GetDelay();
            FlatMSBox.Value = Convert.ToInt32(timer.CalculateFlatMS());
            FlowtimerMSTotalTextBox.Text = ReusableFunctions
                .CreateFlowTimerString(timer.FlowtimerMSTotal());
            InitialConverter = timer;
        }

        private void ReCalculate_Click(object sender, EventArgs e)
        {
            if (InitialConverter != null)
            {
                Recalculate();
            }
            else
            {
                GetConverterSettings();
                InitialConverter = new Timer(Version, NConsole, Method);
                Recalculate();
            }
        }

        private void Recalculate()
        {
            var userInput = ReusableFunctions.ConvertDecimal(GetNewUserInput());
            InitialConverter
                .SetIntroHit(userInput[0])
                .SetFrameHit(userInput[1]);

            IntroMSAdjustBox.Text = InitialConverter.AdjustSeedHit().ToString();
            AdvancesAdjustBox.Text = InitialConverter.AdjustFrameHit().ToString();
            FlatMSBox.Value = Convert.ToDecimal(InitialConverter.RecalculateFlatMS());

            InitialConverter.AdjustIntroMS();
            NewTimerBox.Text =
                ReusableFunctions.CreateFlowTimerString
                (
                    new double[]
                    {
                        InitialConverter.ReturnNewTotal(),
                        InitialConverter.ReturnFinalIntro()
                    }
                );
        }
        private void TVCalcButton_Click(object sender, EventArgs e)
        {
            GetTVSettings();
            var tv = new TeachyTV(TVVersion, TVConsole, TVMethod);
            var input = ReusableFunctions.ConvertDecimal(GetTVInitialInput());
            tv
                .SetIntroTimer(input[0])
                .SetTargetFrame(input[1])
                .SetIntroTimerMS();
            tv.SetOutSideTV(Convert.ToInt32(input[2]));

            TVDelayBox.Value = tv.GetDelay();
            TVFramesInBox.Value = Convert.ToDecimal(tv.GetInsideTVFrames());
            TVFramesTotalBox.Value = Convert.ToDecimal(tv.GetTotalFrames());
            TVMSinTVBox.Value = Convert.ToDecimal(tv.GetTVMS());
            TVMSTotalBox.Value = Convert.ToDecimal(tv.GetTotalMS());
            TVFlowTimerMSTotalBox.Text =
                ReusableFunctions.CreateFlowTimerString
                (
                    new double[]
                    {
                        tv.GetTotalMS(),
                        tv.GetIntroTimer()
                    }
                ); 
        }
        private decimal[] GetInitialUserInput()
        {
            return new decimal[]
            {
                IntroTimerMSBox.Value,
                EncounterAdvancesBox.Value
            };
        }
        private decimal[] GetNewUserInput()
        {
            return new decimal[]
            {
                IntroHitBox.Value,
                EncounterHitBox.Value
            };
        }
        private decimal[] GetTVInitialInput()
        {
            return new decimal[]
            {
                TVIntroTimerMSInitBox.Value,
                TVTargetFrameInitBox.Value,
                TVFramesOutBox.Value
            };
        }
        private void PictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start("https://blisy.net/flowtimerconverter.html");
        }
        private void ConsoleDropDown_SelectionChangeCommitted(object sender, EventArgs e)
        {
            switch (ConsoleDropDown.SelectedIndex)
            {
                case 0:
                case 1:
                case 4:
                    IntroTimerMSBox.Value = 35000;
                    break;

                case 2:
                    IntroTimerMSBox.Value = 2500;
                    break;
                case 3:
                    IntroTimerMSBox.Value = 3500;
                    break;
            }
        }
    }
}
