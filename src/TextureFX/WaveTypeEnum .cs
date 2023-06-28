using System.ComponentModel;


namespace VL.Stride.Effects.TextureFX
{
    [Flags]
    public enum WaveType
    {
        [Description("Sine")]
        Sine = 0,
        [Description("Square")]
        Square = 1,
        [Description("Sawtooth")]
        Sawtooth = 2,
        [Description("Triangle")]
        Triangle = 3,
        [Description("Noise")]
        Noise = 4,
    }
}