using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using STEP.Common.Enums;
using STEP.Core.Models;
using STEP.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace STEP.Services.DataMock
{
    public class MockBillingService : IBillingService
    {
        private readonly List<Bill> _billings;

        public static async Task<MockBillingService> GetService(string url)
        {
            using var client = new HttpClient();

            var jsonString = await client.GetStringAsync(url);

            var billings = JsonConvert.DeserializeObject<List<Bill>>(jsonString);
            return new MockBillingService(billings);
        }

        private MockBillingService(List<Bill> billings)
        {
            _billings = billings;
        }

        private int getPagesNumber(int invoicesCount, int pageSize)
        {
            return Convert.ToInt32(Math.Ceiling(Convert.ToDouble(invoicesCount) / pageSize));
        }

        public Tuple<List<Bill>, int> GetBillingsByPage(int page, int pageSize)
        {
            var pages = getPagesNumber(_billings.Count, pageSize);
            var resultBills = _billings
                .OrderByDescending(b => b.InvoiceYear)
                .ThenByDescending(b => b.InvoiceMonth)
                .Skip(page * pageSize)
                .Take(pageSize).ToList();
            return Tuple.Create(resultBills, pages);
        }

        public Tuple<List<Bill>, int> SortBillingByPeriod(SortTypes sortType, int page, int pageSize)
        {
            var pages = getPagesNumber(_billings.Count, pageSize);
            
            List<Bill> resultBills;
            if (sortType == SortTypes.Descending)
                resultBills = _billings
                    .OrderByDescending(b => b.InvoiceYear)
                    .ThenByDescending(b => b.InvoiceMonth)
                    .Skip(page * pageSize)
                    .Take(pageSize).ToList();
            else
                resultBills = _billings
                    .OrderBy(b => b.InvoiceYear)
                    .OrderBy(b => b.InvoiceMonth)
                    .Skip(page * pageSize)
                    .Take(pageSize).ToList();

            return Tuple.Create(resultBills, pages);
        }
    }
}
