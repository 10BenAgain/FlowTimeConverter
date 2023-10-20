using FlowTimeConverter.Logic;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace FlowTimeConverter
{
    public partial class FlowtimerConverter : Form
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
        }
        private void SetUserSettings()
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
        

        private void CalculateInitialButton_Click(object sender, EventArgs e)
        {
            SetUserSettings();
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
                SetUserSettings();
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

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}
