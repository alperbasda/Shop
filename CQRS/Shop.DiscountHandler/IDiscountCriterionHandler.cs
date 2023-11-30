using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DiscountHandler;

public interface IDiscountCriterionHandler
{
    IDiscountCriterionHandler SetNext(IDiscountCriterionHandler handler);

    object Handle(object request);

    object UseDiscount(object request);
}
