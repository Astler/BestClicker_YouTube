using System.Linq;

namespace AnimatedLight.Data
{
    public static class LightPatterns
    {
        private static readonly LightPatternData Off = new(LightType.Off, "a");
        private static readonly LightPatternData Double = new(LightType.Double, "z");
        private static readonly LightPatternData Normal = new(LightType.Normal, "m");
        private static readonly LightPatternData FlickerFirst = new(LightType.FlickerFirst, "mmnmmommommnonmmonqnmmo");
        private static readonly LightPatternData FlickerSecond = new(LightType.FlickerSecond, "nmonqnmomnmomomno");
        private static readonly LightPatternData SlowStrongPulse = new(LightType.SlowStrongPulse, "abcdefghijklmnopqrstuvwxyzyxwvutsrqponmlkjihgfedcba");
        private static readonly LightPatternData CandleFirst = new(LightType.CandleFirst, "mmmmmaaaaammmmmaaaaaabcdefgabcdefg");
        private static readonly LightPatternData CandleSecond = new(LightType.CandleSecond, "mmmaaaabcdefgmmmmaaaammmaamm");
        private static readonly LightPatternData CandleThird = new(LightType.CandleThird, "mmmaaammmaaammmabcdefaaaammmmabcdefmmmaaaa");
        private static readonly LightPatternData SlowStrobe = new(LightType.SlowStrobe, "aaaaaaaazzzzzzzz");
        private static readonly LightPatternData FastStrobe = new(LightType.FastStrobe, "mamamamamama");
        private static readonly LightPatternData GentlePulse = new(LightType.GentlePulse, "jklmnopqrstuvwxyzyxwvutsrqponmlkj");
        private static readonly LightPatternData SlowPulse = new(LightType.SlowPulse, "abcdefghijklmnopqrrqponmlkjihgfedcba");
        private static readonly LightPatternData DoublePulse = new(LightType.DoublePulse, "mmmaaaabcdefgmmmmaaaammmaamm");
        
        private static readonly LightPatternData[] AllLightPatterns =
        {
            Off, Double, Normal, FlickerFirst, FlickerSecond,
            SlowStrongPulse, CandleFirst, CandleSecond, CandleThird,
            SlowStrobe, FastStrobe, GentlePulse, SlowPulse, DoublePulse,
        };
        
        public static LightPatternData GetPatternDataByType(LightType type)
        {
            return AllLightPatterns.FirstOrDefault(x => x.TypeName == type);
        }
    }
}