
namespace FlowTimeConverter.Logic
{
    public class ReusableFunctions
    {
        /// <summary>
        /// Converts Frames to a Flat MS total without any modifiers
        /// </summary>
        /// <param name="FPS"></param>
        /// <returns></returns>
        public static double FrameToMS(double FPS) => 1 / FPS * 1000;

        /// <summary>
        /// Converts the amount of frames each game lags by to MS.
        /// SeedLag is determined by what version of the game you are playing. (FRLG)
        /// Multiplies Frames by MS converstion then by the seedlag constant
        /// </summary>
        /// <param name="FPS"></param>
        /// <param name="SeedLag"></param>
        /// <returns></returns>
        public static double SeedLagToMS(double FPS, double SeedLag) => 1 / FPS * 1000 * SeedLag;
        public static double FlatMS(double fps, int target, int delay)
        {
            return FrameToMS(fps) * (target + delay);
        }
        public static double TotalTimerMS(double FPS, double seedlag, int target, int delay, int intro)
        {
            // Time after intro plays out. Frame rate MS calculation times the target frame + delay
            var timeNoIntro = FrameToMS(FPS) * (target + delay);
            // Intro time set by user in MS
            var introTime = intro;
            // Seedlag value to add to total MS total for flowtimer
            var seedlagMS = SeedLagToMS(FPS, seedlag);
            return timeNoIntro + introTime + seedlagMS;
        }
    }
}
