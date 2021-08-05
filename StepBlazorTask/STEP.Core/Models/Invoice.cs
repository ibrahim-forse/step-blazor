using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STEP.Core.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public string InvoiceReference { get; set; }
        public int ClientId { get; set; }
        public int ClientBUId { get; set; }
        public string ClientName { get; set; }
        public string ClientBUName { get; set; }
        public int AgencyId { get; set; }
        public int CampaignId { get; set; }
        public string CampaignName { get; set; }
        public int CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public int InvoiceStatusId { get; set; }
        public string InvoiceStatusName { get; set; }
        public string InvoiceStatusColor { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int LastModifiedBy { get; set; }
        public string InvoiceDocument { get; set; }
        public List<string> SupportingDocuments { get; set; }
        public bool IsEditable { get; set; }
        public bool IsDeletable { get; set; }
        public string LatestClientComment { get; set; }
        public string LatestVendorComment { get; set; }
    }
}
