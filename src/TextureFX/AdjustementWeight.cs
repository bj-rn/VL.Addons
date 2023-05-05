using System.ComponentModel;


namespace VL.Stride.Effects.Common
{
    [Flags]
    public enum AdjustementWeight
    {
        [Description("Full")]
        Full = 0,
        [Description("Shadows")]
        Shadows = 1,
        [Description("Midtones")]
        Midtones = 2,
        [Description("Highlights")]
        Highlights = 3,

        [Description("Red")]
        Red = 4,
        [Description("Green")]
        Green = 5,
        [Description("Blue")]
        Blue = 6,

        [Description("Value")]
        Value = 7,
        [Description("Lightness")]
        Lightness = 8,
        [Description("Saturation")]
        Saturation = 9,
        [Description("Hue")]
        Hue = 10,

        [Description("Cyan")]
        Cyan = 11,
        [Description("Magenta")]
        Magenta = 12,
        [Description("Yellow")]
        Yellow = 13,
        [Description("Black")]
        Black = 14,

        [Description("Alpha")]
        Alpha = 15,
        [Description("Long")]
        Long = 16,
        [Description("Medium")]
        Medium = 17,
        [Description("Short")]
        Short = 18,
    }
}