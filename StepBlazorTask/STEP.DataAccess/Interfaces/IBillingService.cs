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
        public List<Bill> GetBillingsByPage(int page, int pageSize);
    }
}
