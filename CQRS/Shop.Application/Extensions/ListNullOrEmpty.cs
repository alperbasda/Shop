using System.Collections;

namespace Shop.Application.Extensions;

public static class ListNullOrEmpty
{
    public static bool IsNullOrEmpty(this IList list)
    {
        return list == null || list.Count == 0;
    }
}
