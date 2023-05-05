using System.ComponentModel;


namespace VL.Stride.Effects.Common
{
    [Flags]
    public enum Glitch
    {
        [Description("Displace")]
        Displace = 0,
        [Description("DispColorLine")]
        DispColorLine = 1,
        [Description("RGBLinesHorizontal")]
        RGBLinesHorizontal = 2,
        [Description("RGBLinesVertical")]
        RGBLinesVertical = 3,
        [Description("Luma")]
        Luma = 4,
    }
}