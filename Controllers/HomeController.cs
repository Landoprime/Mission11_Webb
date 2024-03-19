using Microsoft.AspNetCore.Mvc;
using Mission11_Webb.Models;
using Mission11_Webb.Models.ViewModels;
using System.Diagnostics;

namespace Mission11_Webb.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository repo;
        public HomeController(IBookstoreRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index(int pageNum)
        {
            int pageSize = 10;

            var bookstore = new ProjectsListViewModel
            {
                Books = repo.Books
                    .OrderBy(x => x.Title)  // This part is fine
                    .Skip((pageNum - 1) * pageSize)  // This part is fine
                    .Take(pageSize)  // This part is fine
                    .AsQueryable(),  // Convert to IQueryable<Book>

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = repo.Books.Count()
                }
            };

            return View(bookstore);
        }
    }
}
