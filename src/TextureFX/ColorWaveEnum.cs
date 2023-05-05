using System.ComponentModel;


namespace VL.Stride.Effects.Common
{
    [Flags]
    public enum ColorWave
    {
        [Description("Linear")]
        Linear = 0,
        [Description("Inverse")]
        Inverse = 1,
        [Description("Triangle")]
        Triangle = 2,
        [Description("Sin")]
        Sin = 3,
        [Description("Rectangle")]
        Rectangle = 4,
        [Description("Frac")]
        Frac = 5
    }
}