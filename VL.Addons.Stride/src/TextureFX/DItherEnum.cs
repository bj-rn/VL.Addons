using System.ComponentModel;


namespace VL.Stride.Effects.TextureFX
{
    [Flags]
    public enum Dither
    {
        [Description("Bayer")]
        Bayer = 0,
        [Description("PSX")]
        PSX = 1,
    }
}