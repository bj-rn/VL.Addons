using System.ComponentModel;


namespace VL.Stride.Effects.Common
{
    [Flags]
    public enum Edge
    {
        [Description("Sobel")]
        Sobel = 0,
        [Description("MotorSaw")]
        MotorSaw = 1,
        [Description("Aiekick")]
        Aiekick = 2,
        [Description("Charcoal")]
        Charcoal = 3,
    }
}