using System.ComponentModel;


namespace VL.Stride.Effects.Common
{
    [Flags]
    public enum ColorChannel
    {
        [Description("Red")]
        Red = 0,
        [Description("Green")]
        Green = 1,
        [Description("Blue")]
        Blue = 2,
        [Description("Alpha")]
        Alpha = 3,
        [Description("Value")]
        Value = 4,
        [Description("Lightness")]
        Lightness = 5,
        [Description("Saturation")]
        Saturation = 6,
        [Description("Hue")]
        Hue = 7,
        [Description("Cyan")]
        Cyan = 8,
        [Description("Magenta")]
        Magenta = 9,
        [Description("Yellow")]
        Yellow = 10,
        [Description("Black")]
        Black = 11,
    }
}