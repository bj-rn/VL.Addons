using System.ComponentModel;


namespace VL.Stride.Effects.TextureFX
{
    [Flags]
    public enum ColorspaceConversion
    {
        [Description("Gamma to Linear")]
        GammaToLinear = 0,
        [Description("SRGB to Linear")]
        SRGBToLinear = 1,
        [Description("SRGB to Linear Precise")]
        SRGBToLinearPrecise = 2,
        [Description("Linear to Gamma")]
        LinearToGamma = 3,
        [Description("Linear to SRGB")]
        LinearToSRGB = 4,
        [Description("Linear to SRGB Precise")]
        LinearToSRGBPrecise = 5
    }
}