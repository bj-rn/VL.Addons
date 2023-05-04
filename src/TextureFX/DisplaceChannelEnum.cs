using System.ComponentModel;


namespace VL.Stride.Effects.Common
{
    [Flags]
    public enum DisplaceChannel
    {
        [Description("RGB")]
        RGB = 0,
        [Description("Red")]
        Red = 1,
        [Description("Green")]
        Green = 2,
        [Description("Blue")]
        Blue = 3,
        [Description("RedGreen")]
        RedGreen = 4,
        [Description("RedBlue")]
        RedBlue = 5, 
        [Description("GreenBlue")]
        GreenBlue = 6,
        [Description("Value")]
        Value = 7,
        [Description("Lightness")]
        Lightness = 8,
        [Description("Saturation")]
        Saturation = 9,
        [Description("Hue")]
        Hue = 10,
        [Description("RGBShift")]
        RGBShift = 11,
        [Description("Cyan")]
        Cyan = 12,
        [Description("Magenta")]
        Magenta = 13,
        [Description("Yellow")]
        Yellow = 14,
        [Description("Black")]
        Black = 15,
    }
}