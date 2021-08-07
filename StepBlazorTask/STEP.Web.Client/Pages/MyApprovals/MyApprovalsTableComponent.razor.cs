using STEP.Common.Enums;
using STEP.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STEP.Web.Client.Pages.MyApprovals
{
    public partial class MyApprovalsTableComponent
    {
        int pageSize;
        int currentPage;
        int pageNumber;
        int totalPages;
        int startPage;
        int endPage;
        bool isSearch;
        string searchText;
        bool isSort;
        bool isAscending;
        InvoicesSortKeys globalSortKey;
        SortTypes globalSortType;
        private IEnumerable<Invoice> Elements;
        private Tuple<List<Invoice>, int> Data;

        protected override async Task OnInitializedAsync()
        {//
            currentPage = currentPage == 0 ? 1 : currentPage;
            Console.WriteLine($"##### Current Page {currentPage}");
            pageSize = 3;
            Data = invoicesService.GetInvoicesByPage(currentPage - 1, pageSize);

            totalPages = Data.Item2;
            Elements = Data.Item1;
            calculatePaging();

        }

        void calculatePaging()
        {
            Console.WriteLine($"##### Current Page {currentPage}");
            pageNumber = currentPage;
            totalPages = Convert.ToInt32(Data.Item2);
            startPage = pageNumber - 2;
            endPage = pageNumber + 2;

            if (startPage <= 0)
            {
                endPage -= (startPage - 1);
                startPage = 1;
            }
            if (endPage > totalPages)
            {
                endPage = totalPages;
                if (endPage > 5)
                {
                    startPage = endPage - 4;
                }
            }
            Console.WriteLine($"######### Calculated Paging: StartPage {startPage} EndPage {endPage}");
        }

        async Task navigateToPage(int pageNumber)
        {
            currentPage = pageNumber;
            if (isSearch && !string.IsNullOrEmpty(searchText))
            {
                await SearchInvoiceData(pageNumber, searchText);
            }
            else
            {
                if (isSort)
                {
                    SortResultsClick(globalSortKey, globalSortType, pageNumber);
                }
                else
                {
                    await GetInvoicesData(pageNumber);
                }
            }
        }

        async Task GetInvoicesData(int page)
        {
            Data = invoicesService.GetInvoicesByPage(page - 1, pageSize);

            totalPages = Data.Item2;
            Elements = Data.Item1;
            calculatePaging();
            StateHasChanged();
        }

        async Task searchForInvoiceClick()
        {
            if (!string.IsNullOrEmpty(searchText))
            {
                await SearchInvoiceData(1, searchText);
                isSearch = true;
            }
        }

        async Task SearchInvoiceData(int page, string searchKey)
        {
            Data = invoicesService.SearchInvoicesByNumber(searchKey, page - 1, pageSize);

            totalPages = Data.Item2;
            Elements = Data.Item1;
            calculatePaging();
            StateHasChanged();
        }

        async Task cancelSearchClick()
        {
            searchText = string.Empty;
            isSearch = false;
            Data = invoicesService.GetInvoicesByPage(0, pageSize);
            totalPages = Data.Item2;
            Elements = Data.Item1;
            currentPage = 1;
            calculatePaging();
            StateHasChanged();
        }

        void SortResultsClick(InvoicesSortKeys sortBy, SortTypes sortType, int page)
        {
            currentPage = page;
            isSort = true;
            globalSortKey = sortBy;
            globalSortType = sortType;

            isAscending = (sortType == SortTypes.Ascending) ? true : false;
            Data = invoicesService.SortInvoicesByKeys(globalSortKey, globalSortType, page - 1, pageSize);
            totalPages = Data.Item2;
            Elements = Data.Item1;
            calculatePaging();
            StateHasChanged();
        }
    }
}
