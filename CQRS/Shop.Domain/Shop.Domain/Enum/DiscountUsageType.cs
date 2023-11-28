using System.ComponentModel;

namespace Shop.Domain.Enum;

public enum DiscountUsageType
{
    [Description("Yüzde")]
    Percent = 10,
    [Description("Direk")]
    Direct = 20
}
