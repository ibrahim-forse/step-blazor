using Newtonsoft.Json;
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
    public class MockInvoicesService : IInvoicesService
    {
        private readonly List<Invoice> _invoices;
        public static async Task<MockInvoicesService> GetService(string url)
        {
            using var client = new HttpClient();

            var jsonString = await client.GetStringAsync(url);

            var invoices = JsonConvert.DeserializeObject<List<Invoice>>(jsonString);
            return new MockInvoicesService(invoices);
        }

        private MockInvoicesService(List<Invoice> invoices)
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

        public Tuple<List<Invoice>, int> SortInvoicesByKeys(InvoicesSortKeys sortBy, SortTypes sortType, int page, int pageSize)
        {
            var pages = getPagesNumber(_invoices.Count, pageSize);

            var query = _invoices.AsQueryable();
            
            switch (sortBy)
            {
                case InvoicesSortKeys.ByAgency:
                    if (sortType == SortTypes.Ascending)
                        query = query.OrderBy(i => i.AgencyId);
                    else
                        query = query.OrderByDescending(i => i.AgencyId);
                    break;
                case InvoicesSortKeys.ByAmount:
                    if (sortType == SortTypes.Ascending)
                        query = query.OrderBy(i => i.Amount);
                    else
                        query = query.OrderByDescending(i => i.Amount);
                    break;
                case InvoicesSortKeys.ByBU:
                    if (sortType == SortTypes.Ascending)
                        query = query.OrderBy(i => i.ClientBUName);
                    else
                        query = query.OrderByDescending(i => i.ClientBUName);
                    break;
                case InvoicesSortKeys.ByDate:
                    if (sortType == SortTypes.Ascending)
                        query = query.OrderBy(i => i.CreatedDate);
                    else
                        query = query.OrderByDescending(i => i.CreatedDate);
                    break;
                case InvoicesSortKeys.ByName:
                    if (sortType == SortTypes.Ascending)
                        query = query.OrderBy(i => i.InvoiceNumber);
                    else
                        query = query.OrderByDescending(i => i.InvoiceNumber);
                    break;
                case InvoicesSortKeys.ByStatus:
                    if (sortType == SortTypes.Ascending)
                        query = query.OrderBy(i => i.InvoiceStatusName);
                    else
                        query = query.OrderByDescending(i => i.InvoiceStatusName);
                    break;
                case InvoicesSortKeys.ByVendor:
                    if (sortType == SortTypes.Ascending)
                        query = query.OrderBy(i => i.Vendor);
                    else
                        query = query.OrderByDescending(i => i.Vendor);
                    break;
                default:
                    query = query.OrderByDescending(i => i.CreatedDate);
                    break;
            }
            
            var resultInvoices = query
               .Skip(page * pageSize).Take(pageSize).ToList();
            
            return Tuple.Create(resultInvoices, pages);
        }
    }
}
