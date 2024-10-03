using System.ComponentModel;

namespace Stride.Graphics.BlendStateDescription
{
    [Flags]
    public enum BlendStateEnum
    {
        [Description("Disabled")]
        Disabled = 0,
        [Description("Add")]
        Add = 1,
        [Description("Blend")]
        Blend = 2,
        [Description("Multiply")]
        Multiply = 3,
        [Description("AlphaAdd")]
        AlphaAdd = 4,
        [Description("TextDefault")]
        TextDefault = 5,
        [Description("Keep")]
        Keep = 6,
        [Description("ConstantFactor")]
        ConstantFactor = 7,
        [Description("BlendDestination")]
        BlendDestination = 8,
        [Description("ReplaceApha")]
        ReplaceApha = 9,
        [Description("MultiplyAlpha")]
        MultiplyAlpha = 10,
        [Description("SourceOver")]
        SourceOver = 11,
        [Description("DestinationOver")]
        DestinationOver = 12,
        [Description("SourceOut")]
        SourceOut = 13,
        [Description("DestinationOut")]
        DestinationOut = 14,
        [Description("SourceIn")]
        SourceIn = 15,
        [Description("DestinationIn")]
        DestinationIn = 16,
        [Description("SourceAtop")]
        SourceAtop = 17,
        [Description("DestinationAtop")]
        DestinationAtop = 18,
        [Description("Xor")]
        Xor = 19,
        [Description("Source")]
        Source = 20,
        [Description("Destination")]
        Destination = 21,
        [Description("Clear")]
        Clear = 22,
    }
}