using System.IO;
using Newtonsoft.Json;

namespace FlowTimeConverter.Logic
{
    public class JSONTimer
    {
        public int NConsole { get; set; }
        public int Game { get; set; }
        public int Method { get; set; }
        public decimal TargetFrame { get; set; }
        public decimal TargetFrameHit { get; set; }
        public decimal IntroTimer { get; set; }
        public decimal IntroTimerHit { get; set; }
        public decimal Delay { get; set; }
        public decimal FlatMS { get; set; }
        public string FlowtimerInitial { get; set; }

        public string IntroMSAdjusted { get; set; }
        public string FrameAdjusted { get; set; }
        public string NewAdjusted { get; set; }
    }

    public class JSONTV
    {
        public int NConsole { get; set; }
        public int Game { get; set; }
        public int Method { get; set; }
        public decimal IntroTimer { get; set; }
        public decimal Delay { get; set; }
        public decimal TargetFrame { get; set; }
        public decimal FramesOutofTV { get; set; }
        public decimal FramesInTV { get; set; }
        public decimal FramesTotal { get; set; }
        public decimal MSTV { get; set; }
        public decimal MSTotal { get; set; }
        public string FlowtimerMSTotal { get; set; }

        public decimal AdjustTVFrames { get; set; }
        public decimal AdjustTotalFrames { get; set; }
        public decimal AdjustTVMS { get; set; }
        public decimal AjustTotalMS { get; set; }
        public decimal NewFlowTimerTV { get; set; }
        public string FlowTimerMSTotal { get; set; }
    }

    public class UserJSON
    {
        public string FilePath { get; set; }
        public void SaveTimerInput(JSONTimer timer)
        {
            string json = JsonConvert.SerializeObject(timer, Formatting.Indented);
            File.WriteAllText(FilePath, json);
        }
        public void SaveTVInput(JSONTV tv)
        {
            string json = JsonConvert.SerializeObject(tv, Formatting.Indented);
            File.WriteAllText(FilePath, json);
        }
        public JSONTimer LoadTimerInput()
        {
            string json = File.ReadAllText(FilePath);
            return JsonConvert.DeserializeObject<JSONTimer>(json);
        }
        public JSONTV LoadTVInput()
        {
            string json = File.ReadAllText(FilePath);
            return JsonConvert.DeserializeObject<JSONTV>(json);
        }
    }
}
