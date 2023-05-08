using System.ComponentModel;


namespace VL.Stride.Effects.Common
{
    [Flags]
    public enum ConvertColorType
    {
        [Description("HSVtoRGB")]
        HSVtoRGB = 0,
        [Description("HSLtoRGB")]
        HSLtoRGB = 1,
        [Description("RGBtoHSV")]
        RGBtoHSV = 2,
        [Description("RGBtoHSL")]
        RGBtoHSL = 3,
    }
}