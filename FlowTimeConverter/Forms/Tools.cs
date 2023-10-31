using FlowTimeConverter.Logic;
using System;
using System.Windows.Forms;

namespace FlowTimeConverter
{
    public partial class Tools : Form
    {
        public double FPS { get; set; }
        private void Tools_Load(object sender, EventArgs e)
        {
            ConsoleSelection.SelectedIndex = 0;
            SetFPS(0);
        }
        public Tools()
        {
            InitializeComponent();
        }

        private void FrameMSCalcButton_Click(object sender, EventArgs e)
        {
            var frames = Convert.ToDouble(FrameToMSBox.Value);
            var FrameMS = ReusableFunctions.FrameToMS(FPS, frames);
            FrameMSOutBox.Text = Math.Round(FrameMS).ToString();
        }

        private void MStoFrameCalcButton_Click(object sender, EventArgs e)
        {
            var frames = Convert.ToDouble(MStoFrameBox.Value);
            var FrameMS = ReusableFunctions.MSToFrame(FPS, frames);
            MSFrameOutBox.Text = Math.Round(FrameMS).ToString();
        }

        private void ConsoleSelection_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var select = ConsoleSelection.SelectedIndex;
            SetFPS((byte)select);
        }
        private void SetFPS(byte index)
        {
            FPS = index switch
            {
                0 => Constants.GBAFPS,
                1 => Constants.NDSFPS,
                2 => Constants.NEW3DS,
                3 => Constants.OLD3DS,
                4 => Constants.FPS60,
                _ => 0
            };
        }
    }
}

