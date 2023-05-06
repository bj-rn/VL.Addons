using System.ComponentModel;


namespace VL.Stride.Effects.Common
{
    [Flags]
    public enum LomographType
    {
        [Description("One")]
        One = 0,
        [Description("Two")]
        Two = 1,
        [Description("Three")]
        Three = 2,
        [Description("Four")]
        Four = 3,
        [Description("Five")]
        Five = 4,
        [Description("Six")]
        Six = 5,
        [Description("Gray")]
        Gray = 6,
        [Description("Sepia")]
        Sepia = 7,
    }
}