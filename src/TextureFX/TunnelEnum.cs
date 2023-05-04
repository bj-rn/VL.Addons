using System.ComponentModel;


namespace VL.Stride.Effects.Common
{
    [Flags]
    public enum TunnelType
    {
        [Description("Square")]
        Square = 0,
        [Description("Cylinder")]
        Cylinder = 1,
        [Description("Fly")]
        Fly = 2,
    }
}