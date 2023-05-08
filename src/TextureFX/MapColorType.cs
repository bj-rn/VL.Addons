using System.ComponentModel;


namespace VL.Stride.Effects.Common
{
    [Flags]
    public enum MapColorType
    {
        [Description("Luma")]
        Luma = 0,
        [Description("Hue")]
        Hue = 1,
        [Description("Saturation")]
        Saturation = 2,
        [Description("Value")]
        Value = 3,
        [Description("HueSaturation")]
        HueSaturation = 4,
        [Description("HueValue")]
        HueValue = 5,
        [Description("SaturationValue")]
        SaturationValue = 6,
        [Description("Tone")]
        Tone = 7,
        [Description("RedBlue")]
        RedBlue = 8,
        [Description("RGBA")]
        RGBA =9,
    }
}