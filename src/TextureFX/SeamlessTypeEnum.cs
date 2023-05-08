using System.ComponentModel;


namespace VL.Stride.Effects.Common
{
    [Flags]
    public enum SeamlessType
    {
        [Description("Technique1")]
        Technique1 = 0,
        [Description("Technique2")]
        Technique2 = 1,
        [Description("Technique3")]
        Technique3 = 2,
    }
}