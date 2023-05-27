using System.ComponentModel;


namespace VL.Stride.Effects.TextureFX
{
    [Flags]
    public enum PaletteType
    {
        [Description("HSL")]
        HSL = 0,
        [Description("HSV")]
        HSV = 1,
        [Description("Radial")]
        Radial = 2,
        [Description("Oklab")]
        Oklab = 3,
        [Description("CMYK")]
        CMYK = 4,
        [Description("YUV")]
        YUV = 5,
    }
}