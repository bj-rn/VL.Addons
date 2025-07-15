using System.ComponentModel;


namespace VL.Stride.Effects.TextureFX
{
    [Flags]
    public enum PulseChannel
    {
        [Description("Red")]
        Red = 0,
        [Description("Green")]
        Green = 1,
        [Description("Blue")]
        Blue = 2,
        [Description("RGBtoHSV.x")]
        RGBtoHSVx = 3,
        [Description("RGBtoHSV.y")]
        RGBtoHSVy = 4, 
        [Description("RGBtoHSV.z")]
        RGBtoHSVz = 5,
        [Description("RGBtoHSL.z")]
        RGBtoHSLz = 6,
        [Description("Alpha")]
        Alpha = 7
    }
}