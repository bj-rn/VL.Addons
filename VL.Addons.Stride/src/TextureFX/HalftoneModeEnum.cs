using System.ComponentModel;


namespace VL.Stride.Effects.TextureFX
{
    [Flags]
    public enum HalftoneMode
    {
        [Description("Pixels")]
        Pixels = 0,
        [Description("Halftone")]
        Halftone = 1,
        [Description("SoftHalftone")]
        SoftHalftone = 2,
        [Description("BWHalftone")]
        BWHalftone = 3,
        [Description("LineHalftone")]
        LineHalftone = 4,
        [Description("TexturedHalftone")]
        TexturedHalftone = 5
    }
}