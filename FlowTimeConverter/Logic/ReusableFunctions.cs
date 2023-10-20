
using System;

namespace FlowTimeConverter.Logic
{
    public class ReusableFunctions
    {
        public static double FrameToMS(double FPS, double Frame = 1) => 1 / FPS * 1000 * Frame;
        public static double MSToFrame(double FPS, double Frame = 1) => Frame / 1000 * FPS;
        public static int[] ConvertDecimal(decimal[] input)
        {
            var output = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                output[i] = Convert.ToInt32(input[i]);
            }
            return output;
        }
        public static string CreateFlowTimerString(double[] input)
        {
            var arrayLength = input.Length;
            var arr = new string[arrayLength];
            for (int i = 0; i < arrayLength; i++)
            {
                arr[i] = Math.Round(input[i]).ToString();
            }
            return string.Join("/", arr);
        }
    }
}
