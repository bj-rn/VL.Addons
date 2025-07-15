using System.ComponentModel;


namespace VL.Stride.Effects.TextureFX
{
    [Flags]
    public enum ToneMappingMode
    {
        [Description("Exposure")]
        Exposure = 0,
        [Description("KeyValue")]
        KeyValue = 1,
        [Description("AverageLuminance")]
        AverageLuminance = 2,
    }
}