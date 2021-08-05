using STEP.Common.Enums;
using STEP.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STEP.DataAccess.Interfaces
{
    public interface IBillingService
    {
        Tuple<List<Bill>, int> GetBillingsByPage(int page, int pageSize);
        Tuple<List<Bill>, int> SortBillingByPeriod(SortTypes sortType, int page, int pageSize);
    }
}
