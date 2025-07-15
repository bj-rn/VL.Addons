using System.ComponentModel;


namespace VL.Stride.Effects.TextureFX
{
    [Flags]
    public enum ColorGradingFunction
    {
        [Description("Brightness")]
        Brightness = 0,
        [Description("Contrast")]
        Contrast = 1,
        [Description("Saturation")]
        Saturation = 2,
        [Description("Hue")]
        Hue = 3,
        [Description("Gamma")]
        Gamma = 4,
        [Description("Exposure")]
        Exposure = 5,
        [Description("Gain")]
        Gain = 6,
        [Description("Lift")]
        Lift = 7,
    }
}