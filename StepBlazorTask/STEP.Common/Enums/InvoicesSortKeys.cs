using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STEP.Common.Enums
{
    public enum InvoicesSortKeys
    {
        ByName,
        ByDate,
        ByVendor,
        ByAgency,
        ByBU,
        ByAmount,
        ByStatus
    }

    public enum InvoicesSortType
    {
        Ascending,
        Descending
    }
}
