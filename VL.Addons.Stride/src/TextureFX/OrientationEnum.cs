using System.ComponentModel;


namespace VL.Stride.Effects.TextureFX
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