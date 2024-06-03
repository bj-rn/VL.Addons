using System.ComponentModel;


namespace VL.Stride.Effects.TextureFX
{
    [Flags]
    public enum GradientType
    {
        [Description("RGBA")]
        RGBA = 0,
        [Description("Kubelka-Munk")]
        Spectral = 1
    }
}