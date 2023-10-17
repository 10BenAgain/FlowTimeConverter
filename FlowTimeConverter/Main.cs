using FlowTimeConverter.Logic;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace FlowTimeConverter
{
    public partial class FlowtimerConverter : Form
    {
        public double FPS { get; set; }
        public int SeedLag { get; set; }
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
       
        private void GetUserSettings()
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
            GetUserSettings();
            var timer = new Timer(Version, NConsole, Method);
            FPS = timer.FPS;
            SeedLag = timer.SeedLag;

            timer.SetIntroTimer(Convert.ToInt32(IntroTimerMSBox.Value));
            timer.SetTargetFrame(Convert.ToInt32(EncounterAdvancesBox.Value));

            var values = timer.GetStringValues();
            DelayBox.Value = timer.GetDelay();
            FlatMSTextBox.Text = values[0];
            FlowtimerMSTotalTextBox.Text = $"{values[1]}/{values[2]}";
        }

        private void ReCalculate_Click(object sender, EventArgs e)
        {
            var recalc = new AdjustTimer(
                Convert.ToInt32(EncounterAdvancesBox.Value),
                Convert.ToInt32(IntroTimerMSBox.Value), 
                Convert.ToInt32(EncounterHitBox.Value), 
                Convert.ToInt32(IntroHitBox.Value),
                FPS, SeedLag, Convert.ToInt16(DelayBox.Value));

            IntroMSAdjustBox.Text = recalc.IntroMSAdjust().ToString();
            AdvancesAdjustBox.Text = recalc.AdvancesAdjust().ToString();
            NewTimerBox.Text = recalc.UpdatedFlowTimer();
        }
        private void PictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start("https://blisy.net/flowtimerconverter.html");
        }
    }
}
