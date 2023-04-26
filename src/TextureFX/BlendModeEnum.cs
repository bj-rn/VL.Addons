using System.ComponentModel;


namespace VL.Stride.Effects.Common
{

    public static class ShaderEnums
    {

        [Flags]
        public enum BlendMode
        {
            //MIX
            [Description("Normal")]
            Normal = 0,
            [Description("Average")]
            Average = 1,
            [Description("GeometricMean")]
            GeometricMean = 2,

            //DARKEN
            [Description("Darken")]
            Darken = 3,
            [Description("Multiply")]
            Multiply = 4,
            [Description("ColorBurn")]
            ColorBurn = 5,
            [Description("LinearBurn")]
            LinearBurn =6,
            [Description("DarkerColor")]
            DarkerColor = 7,

            //LIGHTEN
            [Description("Lighten")]
            Lighten = 8,
            [Description("Screen")]
            Screen = 9,
            [Description("Add")]
            Add = 10,
            [Description("LighterColor")]
            LighterColor = 11,
            [Description("Glow")]
            Glow = 12,

            //CONTRAST
            [Description("Overlay")]
            Overlay =13,
            [Description("Softlight")]
            Softlight = 14,
            [Description("ColorDodge")]
            ColorDodge = 15,
            [Description("Reflect")]
            Reflect = 16,
            [Description("HardMix")]
            HardMix = 17,
            [Description("Freeze")]
            Freeze = 18,
            [Description("PinLight")]
            PinLight = 19,
            [Description("Hardlight")]
            Hardlight = 20,
            [Description("Vividlight")]
            Vividlight = 21,
            [Description("LinearLight")]
            LinearLight = 22,

            //INVERSION
            [Description("Difference")]
            Difference = 23,
            [Description("Exclusion")]
            Exclusion = 24,
            [Description("Subtract")]
            Subtract = 25,
            [Description("Divide")]
            Divide = 26,
            [Description("Negation")]
            Negation = 27,
            [Description("AdditiveSubstractive")]
            AdditiveSubstractive = 28,
            [Description("Heat")]
            Heat = 29,
            [Description("Phoenix")]
            Phoenix = 30,
            [Description("GrainExtract")]
            GrainExtract = 31,
            [Description("GrainMerge")]
            GrainMerge = 32,


            //COMPONENT
            [Description("Hue")]
            Hue = 33,
            [Description("Saturation")]
            Saturation = 34,
            [Description("Color")]
            Color = 35,
            [Description("Lightness")]
            Lightness = 36,
            [Description("Value")]
            Value = 37,
            [Description("Red")]
            Red = 38,
            [Description("Green")]
            Green = 39,
            [Description("Blue")]
            Blue = 40,
        }

        public static string ColorString(BlendMode e)
        {
            return e.ToString();
        }

    }
}