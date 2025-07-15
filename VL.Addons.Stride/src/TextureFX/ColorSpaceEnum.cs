using System.ComponentModel;


namespace VL.Stride.Effects.Common
{
    [Flags]
    public enum ColorSpace
    {
        [Description("RGBA")]
        RGBA = 0,
        [Description("HSVA")]
        HSVA = 1,
        [Description("HSLA")]
        HSLA = 2,
        [Description("CMYK")]
        CMYK = 3,
        [Description("OKLAB")]
        OKLAB = 4,
    }
}