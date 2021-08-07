using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace STEP.Web.Server.Controllers
{
    public class SampleController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SampleController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        [Route("Invoices")]
        [HttpGet]
        public IActionResult IndexInvoices()
        {
            string webRootPath = _webHostEnvironment.WebRootPath;
            string contentRootPath = _webHostEnvironment.ContentRootPath;
            var json = System.IO.File.ReadAllText(webRootPath + "SampleData/Invoices.json");
            return Ok(json);
        }

        [Route("Billing")]
        [HttpGet]
        public IActionResult IndexBilling()
        {
            string webRootPath = _webHostEnvironment.WebRootPath;
            string contentRootPath = _webHostEnvironment.ContentRootPath;
            var json = System.IO.File.ReadAllText(webRootPath + "SampleData/Billing.json");
            return Ok(json);
        }
    }
}
