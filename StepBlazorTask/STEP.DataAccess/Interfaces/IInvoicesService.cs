using STEP.Common.Enums;
using STEP.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STEP.DataAccess.Interfaces
{
    public interface IInvoicesService
    {
        Tuple<List<Invoice>,int> GetInvoicesByPage(int page, int pageSize);
        Tuple<List<Invoice>, int> SortInvoicesByKeys(InvoicesSortKeys sortBy, SortTypes sortType, int page, int pageSize);
        Tuple<List<Invoice>, int> SearchInvoicesByNumber(string searchKey, int page, int pageSize);
    }
}
