using System.ComponentModel;


namespace VL.Stride.Effects.Common
{
    [Flags]
    public enum EffectOrientation
    {
        [Description("Horizontal")]
        Horizontal = 0,
        [Description("Vertical")]
        Vertical = 1,
    }
}