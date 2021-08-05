using Newtonsoft.Json;
using STEP.Common.Enums;
using STEP.Core.Models;
using STEP.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STEP.Services.DataMock
{
    public class MockInvoicesService : IInvoicesService
    {
        private readonly List<Invoice> _invoices;
        public MockInvoicesService(List<Invoice> invoices)
        {
            _invoices = invoices;
        }

        private int getPagesNumber(int invoicesCount, int pageSize)
        {
            return Convert.ToInt32(Math.Ceiling(Convert.ToDouble(invoicesCount) / pageSize));
        }

        public Tuple<List<Invoice>, int> GetInvoicesByPage(int page, int pageSize)
        {
            var pages = getPagesNumber(_invoices.Count(), pageSize);
            
            var resultInvoices = _invoices
                .OrderBy(i => i.CreatedDate)
                .Skip(page * pageSize)
                .Take(pageSize).ToList();
            
            return Tuple.Create(resultInvoices, pages);
        }

        public Tuple<List<Invoice>, int> SearchInvoicesByNumber(string searchKey, int page, int pageSize)
        {
            var query = _invoices.Where(i => i.InvoiceNumber.ToLower().Equals(searchKey.ToLower()));
            
            var pages = getPagesNumber(
                query.Count(), pageSize);

            var resultInvoices = query
                .OrderBy(i => i.CreatedDate)
                .Skip(page * pageSize).Take(pageSize).ToList();
            
            return Tuple.Create(resultInvoices, pages);
        }

        public Tuple<List<Invoice>, int> SortInvoicesByKeys(InvoicesSortKeys sortBy, InvoicesSortType sortType, int page, int pageSize)
        {
            var pages = getPagesNumber(_invoices.Count, pageSize);

            var resultInvoices = _invoices
                .OrderBy(i => i.CreatedDate)
                .Skip(page * pageSize)
                .Take(pageSize).ToList();

            return Tuple.Create(resultInvoices, pages);
        }
    }
}
