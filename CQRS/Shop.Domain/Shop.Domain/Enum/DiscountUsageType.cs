using System.ComponentModel;

namespace Shop.Domain.Enum;

public enum DiscountUsageType
{
    [Description("Yüzde")]
    Percent = 10,
    [Description("Direk")]
    Direct = 20
}

public enum DiscountAssignType
{
    [Description("Role Göre")]
    ForRole = 10,
    [Description("Kayıt Tarihine Göre")]
    ForRegisterBeforeYear = 20,
    [Description("Toplam Ödeme Tutarına Göre")]
    ForTotalPrice = 30,
    [Description("Kategorinin Dışındakilere Göre")]
    ForExcludedCategory = 40,
}
