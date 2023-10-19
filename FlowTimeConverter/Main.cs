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

        public FlowtimerConverter()
        {
            InitializeComponent();
        }

        private void FlowtimerConverter_Load_1(object sender, EventArgs e)
        {
            ConsoleDropDown.SelectedItem = "GBA";
            MethodDropDown.SelectedItem = "Method 1/2/4";
            GameDropDown.SelectedItem = "FireRed 1.0";
            IntroTimerMSBox.Value = 35000;
            EncounterAdvancesBox.Value = 1400;
        }
       
        private void SetUserSettings()
        {
            var game = GameDropDown.SelectedItem.ToString();
            Version = game switch
            {
                "FireRed 1.0" => FlowTimeConverter.Selections.Version.FR10,
                "FireRed 1.1" => FlowTimeConverter.Selections.Version.FR11,
                "Leaf Green" => FlowTimeConverter.Selections.Version.LG,
                "Ruby / Sapphire" => FlowTimeConverter.Selections.Version.RS,
                "Emerald" => FlowTimeConverter.Selections.Version.Emerald,
                "SM/USUM" => FlowTimeConverter.Selections.Version.USUM,
                _ => throw new NotImplementedException(),
            };

            var nconsole = ConsoleDropDown.SelectedItem.ToString();
            NConsole = nconsole switch
            {
                "GBA" => FlowTimeConverter.Selections.NConsole.GBA,
                "NDS" => FlowTimeConverter.Selections.NConsole.NDS,
                "New 3DS/2DS" => FlowTimeConverter.Selections.NConsole.N3DS,
                "Old 3DS/2DS" => FlowTimeConverter.Selections.NConsole.O3DS,
                "60FPS" => FlowTimeConverter.Selections.NConsole.FPS60,
                _ => throw new NotImplementedException(),
            };

            var method = MethodDropDown.SelectedItem.ToString();
            Method = method switch
            {
                "Method 1/2/4" => FlowTimeConverter.Selections.Method.M124,
                "Sweet Scent(Outdoors)" => FlowTimeConverter.Selections.Method.SCO,
                "Sweet Scent(Indoors)" => FlowTimeConverter.Selections.Method.SCI,
                "IDRNG" => FlowTimeConverter.Selections.Method.ID,
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
        
    }
}
