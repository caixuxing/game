namespace Ooph.Core.Attribute;

/// <summary>
/// 枚举分组
/// </summary>
[AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field)]
public class EnumGroupAttribute : System.Attribute
{
    public List<int> Parent { get; set; }

    public EnumGroupAttribute(params int[] values)
    {
        Parent = new List<int>(values);
    }
}
