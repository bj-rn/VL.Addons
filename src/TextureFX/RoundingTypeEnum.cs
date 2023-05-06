using System.ComponentModel;


namespace VL.Stride.Effects.Common
{
    [Flags]
    public enum RoundingType
    {
        [Description("Round")]
        Round = 0,
        [Description("Floor")]
        Floor = 1,
        [Description("Ceil")]
        Ceil = 2,
    }
}