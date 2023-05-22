using System.ComponentModel;


namespace VL.Stride.Effects.TextureFX
{
    [Flags]
    public enum ChannelKeyingType
    {
        [Description("Alpha")]
        Alpha = 0,
        [Description("Red")]
        Red = 1,
        [Description("Green")]
        Green = 2,
        [Description("Blue")]
        Blue = 3,
        [Description("Luma")]
        Luma = 4,
        [Description("Saturation")]
        Saturation = 5,
    }
}